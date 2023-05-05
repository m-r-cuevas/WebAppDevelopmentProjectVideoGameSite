using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoleCafe.WebSite.Models;
using ConsoleCafe.WebSite.Services;

namespace ConsoleCafe.WebSite.Pages.Product
{
    public class ViewModel : PageModel
    {
        // Getting the data from the JSON file.
        public JsonFileProductService ProductService { get; }

        // Initializing the product service.
        public ViewModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The product that will be displayed on the page.
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