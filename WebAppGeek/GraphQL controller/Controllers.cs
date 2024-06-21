using Microsoft.AspNetCore.Mvc;
using System;
using WebAppGeek.Abstraction;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;

        public GraphQLController(IProductRepository productRepository, IProductGroupRepository productGroupRepository)
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
        }

        [HttpPost]
        public ActionResult<dynamic> ExecuteQuery(string query)
        {
            try
            {
                // Process the GraphQL query here
                // Use _productRepository and _productGroupRepository to fetch data
                return Ok("Query executed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}