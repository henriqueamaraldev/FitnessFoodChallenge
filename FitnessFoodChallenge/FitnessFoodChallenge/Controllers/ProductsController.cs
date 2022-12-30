using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.models;

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
            return "Fullstack Challenge 20201026";
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts([FromRoute] PaginatedRequest request)
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
                _logger.LogError("1", e);
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
                _logger.LogError("2", e);
                return BadRequest();
            }
        }
    }
}
