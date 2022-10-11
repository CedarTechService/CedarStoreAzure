
namespace CatalogAPI.Models
{
    public class Product
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
    }
}