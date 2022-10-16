namespace CatalogAPI.Tests
{
    public class ProductServiceTest
    {
        IProductService _productService;
        Mock<IProductRepository> _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceTest()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new ProductsProfile()));
            _mapper = mapperConfig.CreateMapper();

            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(x => x.GetAllProducts()).Returns(() => new List<Product> { new Product() { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F }, new Product() { Id = 2, Name = "Football", Category = "Sports", Price = 29.99F } });
            _productRepository.Setup(x => x.GetProductById(1)).Returns(new Product() { Id = 1, Name = "Basketball", Category = "Sports", Price = 12.50F });
            _productService = new ProductService(productRepository: _productRepository.Object, mapper: _mapper);
        }

        [Fact]
        public void GetProductById_ReturnsCorrectTypeAndValue_WhenExistingResourceIdSubmitted()
        {
            var result = _productService.GetProductById(1);

            Assert.IsType<ProductReadDto>(result);
            Assert.Equal(1, result?.Id);
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

            Assert.IsType<List<ProductReadDto>>(result);
            Assert.Equal("Basketball", result?.FirstOrDefault()?.Name);
        }


    }
}