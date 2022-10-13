namespace CatalogAPI.Tests
{
    public class CatalogControllerTest
    {
        private CatalogController? _catalogController;
        private Mock<IProductService> _mockProductService;
        // private ILogger<CatalogController> _logger;
        public CatalogControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
        }

        [Fact]
        public void GetAllProducts_ReturnsCorrectType_WhenDBHasResource()
        {
            var products = new List<Product>() { new Product() };// { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F } };
            _mockProductService.Setup(x => x.GetAllProducts()).Returns(() => new List<Product> { new Product() { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F } });
            _catalogController = new CatalogController(_mockProductService.Object);

            var result = _catalogController.GetAllProducts();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<Product>>>(result);
            Assert.IsType<OkObjectResult>(result.Result);
            // Assert.IsType<IEnumerable<Product>?>(result.Value);
            // Assert.Equal("Basketball", result.Value?.FirstOrDefault<Product>()?.Name);
        }

        [Fact]
        public void GetProductById_ReturnsCorrectType_WhenExistentResourceIdSubmitted()
        {
            // var result = _catalogController.GetProductById();

        }

    }
}