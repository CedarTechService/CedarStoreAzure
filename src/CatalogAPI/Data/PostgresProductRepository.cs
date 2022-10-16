namespace CatalogAPI.Data
{
    public class PostgresProductRepository : IProductRepository
    {
        private ProductContext _context;
        public PostgresProductRepository(ProductContext context) => _context = context;

        public List<Product>? GetAllProducts() => _context.ProductItems?.ToList<Product>();

        public Product? GetProductById(long productId) => _context.ProductItems?.FirstOrDefault(p => p.Id == productId);
    }
}