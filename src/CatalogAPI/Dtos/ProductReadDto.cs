namespace CatalogAPI.Dtos
{
    public class ProductReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}