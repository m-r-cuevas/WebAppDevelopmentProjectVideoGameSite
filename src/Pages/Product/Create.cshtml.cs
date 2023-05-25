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
        // Create a logger object
        private ILogger<CreateModel> _logger;


        /// <summary>
        /// Created a JsonFileProductService object.
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Object ProductService created.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(ILogger<CreateModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// Created a ProductModel object with a getter and a setter.
        /// </summary>
        public ProductModel Product;

        /// <summary>
        /// When called, this method will create a new product and redirects the user to the Update Page.
        /// </summary>
        public IActionResult OnGet()
        {
            return RedirectToPage("./Update", new { Id = "temp" });
        }
    }
}