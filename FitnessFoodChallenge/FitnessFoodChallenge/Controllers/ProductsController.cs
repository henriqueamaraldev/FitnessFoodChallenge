using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessFoodChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public string HelloWorld()
        {
            return "Fullstack Challenge 20201026";
        }

        [HttpGet]
        [Route("products")]
        public string GetProducts()
        {
            return "Not implemented yet";
        }

        [HttpGet]
        [Route("products/{id}")]
        public string GetProduct(long id)
        {
            return "Not implemented yet";
        }
    }
}
