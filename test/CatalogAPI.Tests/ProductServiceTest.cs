namespace CatalogAPI.Tests
{
    public class ProductServiceTest
    {
        IProductService _productService;
        Mock<IProductRepository> _productRepository;
        Product product = new Product { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F };
        List<Product> products;

        public ProductServiceTest()
        {
            products = new List<Product> { product };
            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(x => x.GetAllProducts()).Returns(products);
            _productRepository.Setup(x => x.GetProductById(1)).Returns(product);
            _productService = new ProductService(_productRepository.Object);
        }

        [Fact]
        public void GetProductById_ReturnsCorrectTypeAndValue_WhenExistingResourceIdSubmitted()
        {
            var result = _productService.GetProductById(1);

            Assert.IsType<Product>(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetProductById_ReturnsNull_WhenNonExistingResourceIdSubmitted()
        {
            var result = _productService.GetProductById(2);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllProducts_ReturnsCorrectTypeandValue()
        {
            var result = _productService.GetAllProducts();

            Assert.IsType<List<Product>>(result);
            Assert.Equal("Basketball", result.FirstOrDefault()?.Name);
        }


    }
}