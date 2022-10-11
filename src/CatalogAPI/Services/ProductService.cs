namespace CatalogAPI.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}