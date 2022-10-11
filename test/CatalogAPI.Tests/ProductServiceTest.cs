namespace CatalogAPI.Tests
{
    public class ProductServiceTest
    {
        IProductService _productService;
        // Mock<IProductRepository> _productRepository;
        public ProductServiceTest()
        {
            var products = new List<Product> { new Product { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F } };
            var _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(x => x.GetProducts()).Returns(products);
            _productService = new ProductService(_productRepository.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturnProductList()
        {
            var result = _productService.GetProducts();

            Assert.IsType<List<Product>>(result);
            Assert.Equal("Basketball", result.FirstOrDefault()?.Name);
        }
    }
}