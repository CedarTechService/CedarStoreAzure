using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace CatalogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductService productService, ILogger<CatalogController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            List<ProductReadDto>? productReadDtoItems = null;
            ActionResult? result;
            try
            {
                productReadDtoItems = _productService.GetAllProducts()?.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (productReadDtoItems is null)
                {
                    result = NotFound();
                }
                else
                {
                    result = Ok(productReadDtoItems);
                }
            }
            return result;
        }

        [Authorize]
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