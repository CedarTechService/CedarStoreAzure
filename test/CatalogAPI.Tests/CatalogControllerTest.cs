namespace CatalogAPI.Tests
{
    public class CatalogControllerTest
    {
        private CatalogController _catalogController;
        private Mock<IProductService> _productService;
        // private ILogger<CatalogController> _logger;
        public CatalogControllerTest()
        {
            _productService = new Mock<IProductService>();
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F });
            _productService.Setup(x => x.GetProducts()).Returns(() => products);
            _catalogController = new CatalogController(_productService.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturnProductList()
        {
            var result = _catalogController.GetProducts();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<Product>>>(result);
            // Assert.IsType<IEnumerable<Product>>(result.Value);
            // Assert.Equal("Basketball", result?.FirstOrDefault<Product>()?.Name);
        }
    }
}