namespace CatalogAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public IEnumerable<ProductReadDto>? GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductReadDto>>(_productRepository.GetAllProducts());
        }

        public ProductReadDto? GetProductById(long productId)
        {
            return _mapper.Map<ProductReadDto>(_productRepository.GetProductById(productId));
        }
    }
}