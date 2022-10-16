namespace CatalogAPI.Tests
{
    public class CatalogControllerTest
    {
        private readonly CatalogController? _catalogController;
        private readonly Mock<IProductService> _mockProductService;
        private readonly IMapper _mapper;
        // private ILogger<CatalogController> _logger;
        public CatalogControllerTest()
        {
            _mockProductService = new Mock<IProductService>();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new ProductsProfile()));
            _mapper = mapperConfig.CreateMapper();

            _catalogController = new CatalogController(productService: _mockProductService.Object, mapper: _mapper);
        }

        [Fact]
        public void GetAllProducts_ReturnsCorrectType_WhenDBHasResource()
        {
            var products = new List<Product>() { new Product() };// { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F } };
            _mockProductService.Setup(x => x.GetAllProducts()).Returns(() => new List<Product> { new Product() { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F } });

            var result = _catalogController?.GetAllProducts();

            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<ProductReadDto>>>(result);
            Assert.IsType<OkObjectResult>(result?.Result);
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