using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ConsoleCafe.WebSite.Models;
using ConsoleCafe.WebSite.Services;


namespace ConsoleCafe.WebSite.Pages.Product
{

    /// <summary>
    /// This is the CreateModel class page.
    /// It is based on the UpdateModel class page.
    /// </summary>
    public class CreateModel : PageModel
    {
        private ILogger<CreateModel> _logger;


        //Created a JsonFileProductService object.
        public JsonFileProductService ProductService { get; }

        //Object ProductService created.

        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }


        //Created a ProductModel object with a getter and a setter.
        public ProductModel Product;

        //When called, this method will create a new product and redirects the user to the Update Page.
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            return RedirectToPage("./Update", new { Id = "temp" });
        }
    }
}