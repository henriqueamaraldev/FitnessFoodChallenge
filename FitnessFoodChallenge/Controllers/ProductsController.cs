using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.models;
using System.Text;

namespace FitnessFoodChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productsService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductsServices productsServices, ILogger<ProductsController> logger)
        {
            _productsService = productsServices;
            _logger = logger;
        }
        [HttpGet]
        [Route("/")]
        public string HelloWorld()
        {
            byte[] data = Convert.FromBase64String("RnVsbHN0YWNrIENoYWxsZW5nZSAyMDIwMTAyNg==");
            string decodedString = Encoding.UTF8.GetString(data);
            return decodedString;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts([FromQuery] PaginatedRequest request)
        {
            try
            {
                var paginatedProducts = await _productsService.GetPaginatedProductsAsync(request);

                if (paginatedProducts == null)
                {
                    return BadRequest();
                }
                if (!paginatedProducts.Results.Any())
                {
                    return NoContent();
                }
                return Ok(paginatedProducts);
            }
            catch(Exception e)
            {
                _logger.LogError("GetAllProducts route error", e);
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("products/{id}")]
        public async Task<IActionResult> IActionResultGetProduct(string id)
        {
            try
            {
                var product = await _productsService.GetProductsByIdAsync(id);

                if (product == null)
                {
                    return NotFound("There is no product with this Id");
                }

                return Ok(product);
            } 
            catch(Exception e)
            {
                _logger.LogError("GetProductById route error.", e);
                return BadRequest();
            }
        }
    }
}
