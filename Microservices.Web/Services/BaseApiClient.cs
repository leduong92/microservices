using Microservices.Shared;
using static Microservices.Shared.SD;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using Microservices.Web.Services.IService;

namespace Microservices.Web.Services
{
    public class BaseApiClient : IBaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        private readonly IConfiguration _configuration;
        private readonly ILogger<BaseApiClient> _logger;
        private readonly IMemoryCache _memoryCache;
        private static readonly Dictionary<Type, PropertyInfo[]> _propertyCache = new Dictionary<Type, PropertyInfo[]>();
        public BaseApiClient(IHttpClientFactory httpClientFactory
            , ITokenProvider tokenProvider
            , ILogger<BaseApiClient> logger
            , IConfiguration configuration
            , IMemoryCache memoryCache)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
            _memoryCache = memoryCache;
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<ApiResponse<T>> SendAsync<T>(RequestDto requestDto, bool withBearer = true, CancellationToken cancellationToken = default)
        {
            if (requestDto == null) throw new ArgumentNullException(nameof(requestDto));
            if (string.IsNullOrEmpty(requestDto.Url)) throw new ArgumentException("URL is required", nameof(requestDto.Url));

            _logger.LogInformation("Starting request to {Url} (Attempt 1)", requestDto.Url);
            var client = _httpClientFactory.CreateClient("ECommerceApi");
            using var message = CreateHttpRequestMessage(requestDto, withBearer);
            _logger.LogInformation("Sending {Method} request to {Url}", message.Method, requestDto.Url);
            var response = await client.SendAsync(message, HttpCompletionOption.ResponseHeadersRead);
            var result = await HandleResponseAsync<T>(response);
            return result;
        }

        private HttpRequestMessage CreateHttpRequestMessage(RequestDto requestDto, bool withBearer)
        {
            var message = new HttpRequestMessage();

            message.Headers.Accept.Clear();
            message.Headers.Add("Accept", "application/json");

            var apiKey = _configuration["ApiSettings:ApiKey"];
            if (!string.IsNullOrEmpty(apiKey))
            {
                message.Headers.Add("X-Api-Key", apiKey);
            }

            if (withBearer)
            {
                var token = _tokenProvider.GetToken();
                if (string.IsNullOrEmpty(token))
                {
                    _logger.LogWarning("Empty token");
                }
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            message.RequestUri = new Uri(requestDto.Url.Trim(), UriKind.RelativeOrAbsolute);

            if (requestDto.ContentType == ContentHeaderType.MultipartFormData)
            {
                var content = new MultipartFormDataContent();
                AddPropertiesToMultipartContent(content, requestDto.Data, "");
                message.Content = content;
            }
            else if (requestDto.Data != null)
            {
                message.Content = new StringContent(
                    JsonConvert.SerializeObject(requestDto.Data),
                    Encoding.UTF8,
                    "application/json");
            }
            else
            {
                _logger.LogInformation("No request body");
            }

            message.Method = requestDto.ApiType switch
            {
                ApiType.POST => HttpMethod.Post,
                ApiType.DELETE => HttpMethod.Delete,
                ApiType.PUT => HttpMethod.Put,
                _ => HttpMethod.Get,
            };

            return message;
        }

        private async Task<ApiResponse<T>> HandleResponseAsync<T>(HttpResponseMessage response)
        {
            try
            {
                _logger.LogInformation("Response Headers: {Headers}", JsonConvert.SerializeObject(response.Headers));

                using var stream = await response.Content.ReadAsStreamAsync();
                using var reader = new StreamReader(stream);
                var rawContent = await reader.ReadToEndAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Request failed with status code {StatusCode}", response.StatusCode);
                    return ApiResponse<T>.Failure($"Request failed with status {response.StatusCode}", (int)response.StatusCode);
                }

                if (string.IsNullOrEmpty(rawContent))
                {
                    _logger.LogWarning("Response content is empty");
                    return ApiResponse<T>.Success(default);
                }

                try
                {
                    // Configure Newtonsoft.Json to be case-insensitive
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        },
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    // Deserialize into ApiResponse<T>
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(rawContent, settings);
                    if (apiResponse == null)
                    {
                        _logger.LogWarning("Deserialization returned null, creating default ApiResponse<T>");
                        return ApiResponse<T>.Success(default);
                    }

                    _logger.LogInformation("Deserialized Data: {Data}", JsonConvert.SerializeObject(apiResponse).Substring(0, Math.Min(rawContent?.Length ?? 0, 100)) + "...");
                    return apiResponse;
                }
                catch (JsonException ex)
                {
                    _logger.LogError(ex, "Failed to deserialize response: {Message}", ex.Message);
                    return ApiResponse<T>.Failure($"Deserialization failed: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read response content: {Message}", ex.Message);
                return ApiResponse<T>.Failure($"Failed to read response content: {ex.Message}");
            }
        }
        private PropertyInfo[] GetCachedProperties(Type type)
        {
            if (!_propertyCache.TryGetValue(type, out var properties))
            {
                properties = type.GetProperties();
                _propertyCache[type] = properties;
            }
            return properties;
        }
        private void AddPropertiesToMultipartContent(MultipartFormDataContent content, object data, string prefix, int depth = 0, int maxDepth = 5)
        {
            if (data == null || depth > maxDepth) return;

            var properties = GetCachedProperties(data.GetType());
            // Duyệt qua tất cả các thuộc tính của object
            foreach (var prop in properties)
            {
                var value = prop.GetValue(data);
                if (value == null) continue;

                // Tạo tên cho thuộc tính (bao gồm cả prefix nếu là thuộc tính lồng nhau)
                var propName = string.IsNullOrEmpty(prefix) ? prop.Name : $"{prefix}.{prop.Name}";

                // Nếu là IFormFile
                if (value is IFormFile file)
                {
                    content.Add(new StreamContent(file.OpenReadStream()), propName, file.FileName);
                }
                // Nếu là danh sách (List<T>)
                else if (value is IEnumerable<object> list && value.GetType().IsGenericType)
                {
                    int index = 0;
                    foreach (var item in list)
                    {
                        // Tạo tên cho phần tử trong danh sách (ví dụ: NPTDtos[0])
                        var itemPrefix = $"{propName}[{index}]";
                        AddPropertiesToMultipartContent(content, item, itemPrefix, depth + 1, maxDepth);
                        index++;
                    }
                }
                // Nếu là object (không phải danh sách, không phải IFormFile)
                else if (value.GetType().IsClass && value.GetType() != typeof(string))
                {
                    // Đệ quy để xử lý các thuộc tính của object con
                    AddPropertiesToMultipartContent(content, value, propName, depth + 1, maxDepth);
                }
                // Nếu là giá trị thông thường (string, int, Guid, v.v.)
                else
                {
                    content.Add(new StringContent(value.ToString()), propName);
                }
            }
        }
    }
}
