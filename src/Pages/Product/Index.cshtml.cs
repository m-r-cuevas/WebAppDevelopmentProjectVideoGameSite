using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoleCafe.WebSite.Models;
using ConsoleCafe.WebSite.Services;

namespace ConsoleCafe.WebSite.Pages.Product
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Initializes a new instance of the IndexModel class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// Gets the product service.
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Handles the GET request for the index page.
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}