namespace Microservices.Shared
{
    public class SD
    {
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public static string LocalizationAPIBase { get; set; }
        public static string RegionAPIBase { get; set; }

        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
        public enum ContentHeaderType
        {
            Json,
            MultipartFormData,
        }
    }
}
