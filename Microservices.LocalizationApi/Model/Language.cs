using System.ComponentModel.DataAnnotations;

namespace Microservices.LocalizationApi.Model
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(24)]
        public string? Code { get; set; }
        [MaxLength(128)]
        public string? Name { get; set; }
    }
}
