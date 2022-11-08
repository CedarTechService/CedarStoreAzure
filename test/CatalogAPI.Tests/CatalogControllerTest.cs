using Microsoft.Extensions.Logging.Abstractions;

namespace CatalogAPI.Tests
{
    public class CatalogControllerTest
    {
        private readonly CatalogController? _catalogController;
        private readonly Mock<IProductService> _mockProductService;
        private ILogger<CatalogController> _logger = NullLogger<CatalogController>.Instance; //ILogger mock
        public CatalogControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
            _catalogController = new CatalogController(productService: _mockProductService.Object, _logger);
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

            var okResult = result?.Result as OkObjectResult; //convert type
            var productReadDtoList = okResult?.Value as List<ProductReadDto>;
            Assert.Equal(2, productReadDtoList?.Count);
            Assert.Equal("Basketball", productReadDtoList?.FirstOrDefault<ProductReadDto>()?.Name);
        }

        [Fact]
        public void GetAllProducts_Returns404NotFound_WhenDBHasNotResource()
        {
            // Given
            _mockProductService.Setup(repo => repo.GetAllProducts())
                .Returns(() => null);
            // When
            var result = _catalogController?.GetAllProducts();
            // Then
            Assert.IsType<NotFoundResult>(result?.Result);
        }


        [Fact]
        public void GetProductById_ReturnsCorrectType_WhenExistentResourceIdSubmitted()
        {
            _mockProductService.Setup(x => x.GetProductById(2)).Returns(() => new ProductReadDto() { Id = 2, Name = "Football", Category = "Sports", Price = 29.99F });
            var result = _catalogController?.GetProductById(2);

            Assert.IsType<OkObjectResult>(result?.Result);

            var okResult = result?.Result as OkObjectResult;
            var productReadDto = okResult?.Value as ProductReadDto;
            Assert.Equal(2, productReadDto?.Id);
        }

    }
}