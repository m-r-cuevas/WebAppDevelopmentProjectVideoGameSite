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


        //Create a JsonFileLocationService object called LocationService with a getter.
        public JsonFileProductService ProductService { get; }

        //Initialize the LocationService object.
        public CreateModel(ILogger<CreateModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }
        

        //Create a LocationModel object called Location with a getter and setter.
        public ProductModel Product;

        //When called, this method will create a new location and redirect the user to the Update page for that location which is why it looks similar to the UpdateModel class page.
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            return RedirectToPage("./Update", new { Id = Product.Id });
        }
    }
}