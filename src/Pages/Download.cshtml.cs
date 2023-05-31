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

        /// <summary>
        /// Calculates the average rating for the specified product.
        /// </summary>
        /// <param name="productId">The ID of the product to calculate the average rating for.</param>
        /// <returns>The average rating for the product.</returns>
        public object GetAverageRating(string productId)
        {
            var products = ProductService.GetProducts();

            // Get the ratings for the specified product.
            var ratings = products.First(x => x.Id == productId).Ratings;

            // Calculate the average rating.
            double average = 0;
            if (ratings != null)
            {
                average = ratings.Average();
            }

            return average;
        }
    }
}