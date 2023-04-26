using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;


using ContosoCrafts.WebSite.Models;

using ContosoCrafts.WebSite.Services;

 

namespace ContosoCrafts.WebSite.Pages.Product

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


        public ProductModel Product;


        public void OnGet(string id)
        { 
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));

        }
 

        public object GetAverageRating(string productId)
        {


            var products = ProductService.GetProducts();

            var ratings = products.First(x => x.Id == productId).Ratings;

            double average = 0;

            if (ratings != null)

            {

                average = ratings.Average();

            }

            return average;

        }

    }

}





