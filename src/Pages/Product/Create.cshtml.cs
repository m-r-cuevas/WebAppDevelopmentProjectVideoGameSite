using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;


namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// This is the CreateModel class page. This will allow users to create a new location.
    /// It is based on the UpdateModel class page.
    /// </summary>
    public class CreateModel : PageModel
    {
        private ILogger<CreateModel> _logger;


        //Created a JsonFileLocationService object.
        public JsonFileProductService ProductService { get; }

        //Object ProductService created.
        public CreateModel(ILogger<CreateModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }
        

        //Created a ProductModel object with a getter and a setter.
        public ProductModel Product;

        //When called, this method will create a new product and redirects the user to the Update Page.
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            return RedirectToPage("./Update", new { Id = Product.Id });
        }
    }
}