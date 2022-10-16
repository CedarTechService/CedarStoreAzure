namespace CatalogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CatalogController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var productItems = _productService.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
        }
        [HttpGet("{productId}")]
        // [Route("{productId}")]
        public ActionResult<ProductReadDto> GetProductById(long productId)
        {
            var product = _productService.GetProductById(productId);
            return Ok(_mapper.Map<ProductReadDto>(product));
        }



    }
}