namespace CatalogAPI.Tests
{
    public class CatalogControllerTest
    {
        private readonly CatalogController? _catalogController;
        private readonly Mock<IProductService> _mockProductService;
        // private ILogger<CatalogController> _logger;
        public CatalogControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
            _catalogController = new CatalogController(productService: _mockProductService.Object);
        }

        [Fact]
        public void GetAllProducts_ReturnsCorrectType_WhenDBHasResource()
        {
            // var products = new List<Product>() { new Product() };// { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F } };
            _mockProductService.Setup(x => x.GetAllProducts()).Returns(() => new List<ProductReadDto> { new ProductReadDto() { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F }, new ProductReadDto() { Id = 2, Name = "Football", Category = "Sports", Price = 29.99F } });

            var result = _catalogController?.GetAllProducts();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<ProductReadDto>>>(result);
            Assert.IsType<OkObjectResult>(result?.Result);
            // Assert.IsType<IEnumerable<ProductReadDto>>(result?.Value);
            // Assert.Equal(2, result?.Value?.ToList().Count);
            // Assert.Equal("Basketball", result.Value?.FirstOrDefault<Product>()?.Name);
        }

        [Fact]
        public void GetProductById_ReturnsCorrectType_WhenExistentResourceIdSubmitted()
        {
            // _mockProductService.Setup(x => x.GetProductById(2)).Returns(() => new Product() { Id = 2, Name = "Football", Category = "Sports", Price = 29.99F });
            // ActionResult<ProductReadDto>? result = _catalogController?.GetProductById(2);

            // Assert.IsType<ProductReadDto>(result?.Value);
            // Assert.Equal(2, result?.Value?.Id);
        }

    }
}