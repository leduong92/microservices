namespace Microservices.ProductApi.Model
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdateddAt { get; set; }
    }
}
