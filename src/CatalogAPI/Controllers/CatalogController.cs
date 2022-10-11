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
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return new OkObjectResult(_productService.GetProducts());
        }
    }
}