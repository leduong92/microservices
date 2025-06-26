using System.ComponentModel.DataAnnotations;

namespace Microservices.RegionApi.Model
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(24)]
        public string? Code { get; set; }
        [MaxLength(128)]
        public string? Name { get; set; }
        [MaxLength(12)]
        public string? Currency { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
    }
}
