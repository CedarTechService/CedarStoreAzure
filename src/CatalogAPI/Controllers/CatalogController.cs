namespace CatalogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var productReadDtoItems = _productService.GetAllProducts();
            return Ok(productReadDtoItems);
        }
        [HttpGet("{productId}")]
        // [Route("{productId}")]
        public ActionResult<ProductReadDto> GetProductById(long productId)
        {
            var productReadDto = _productService.GetProductById(productId);
            return Ok(productReadDto);
        }



    }
}