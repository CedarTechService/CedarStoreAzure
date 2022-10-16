namespace CatalogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }
        [HttpGet]
        [Route("{productId}")]
        public ActionResult<Product> GetProductById(long productId)
        {
            return Ok(_productService.GetProductById(productId));
        }



    }
}