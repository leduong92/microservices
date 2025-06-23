
using System.Net.Mime;

using static Microservices.Shared.SD;

namespace Microservices.Shared
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string? Url { get; set; }
        public object? Data { get; set; }
        public string? AccessToken { get; set; }
        public ContentHeaderType ContentType { get; set; } = ContentHeaderType.Json;
    }
}
