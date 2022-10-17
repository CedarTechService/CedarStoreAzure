namespace CatalogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _productService;
        // private readonly ILogger _logger;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
            // _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var productReadDtoItems = new List<ProductReadDto>();
            try
            {
                productReadDtoItems = _productService.GetAllProducts()?.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(productReadDtoItems);
        }
        [HttpGet("{productId}")]
        // [Route("{productId}")]
        public ActionResult<ProductReadDto> GetProductById(long productId)
        {
            var productReadDto = new ProductReadDto();
            try
            {
                productReadDto = _productService.GetProductById(productId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok(productReadDto);
        }
    }
}