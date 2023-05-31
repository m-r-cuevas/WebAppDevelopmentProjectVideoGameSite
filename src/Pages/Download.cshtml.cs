using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoleCafe.WebSite.Models;
using ConsoleCafe.WebSite.Services;

namespace ConsoleCafe.WebSite.Pages
{
    /// <summary>
    /// The DownloadModel is the page model for the download page of the Console Cafe website.
    /// </summary>
    public class DownloadModel : PageModel
    {
        /// <summary>
        /// Getting the data from the JSON file.
        /// </summary>
        public JsonFileProductService ProductService { get; } 

        /// <summary>
        /// Initializing the product service.
        /// </summary>
        /// <param name="productService"></param>
        public DownloadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// The product that will be displayed on the page.
        /// </summary>
        public ProductModel Product;

        /// <summary>
        /// Called when the page is requested.
        /// </summary>
        /// <param name="id">The ID of the product to display.</param>
        public void OnGet(string id)
        {
            // Find the product with the specified ID.
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }

      
    }
}