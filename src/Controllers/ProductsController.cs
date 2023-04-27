using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// ProductsController
    /// Deals with CRUDi requests made to website.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Constructor to the ProductsController class
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// Getter method for the ProductService.
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// This is the Read method in CRUDi.
        /// Uses HttpGet to get all the products.
        /// </summary>
        /// <returns>List of all products.</returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetProducts();
        }

        /// <summary>
        /// This method receives a request body with two properties "ProductId" and "Rating".
        /// </summary>
        /// <param name="request"></param>
        /// <returns>HTTP Response Code.</returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /// <summary>
        /// This class is used to encapsulate "ProductId" and "Rating" values submitted by the users.
        /// </summary>
        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}