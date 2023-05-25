using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ConsoleCafe.WebSite.Models;
using ConsoleCafe.WebSite.Services;
using Microsoft.Extensions.Logging;

namespace ConsoleCafe.WebSite.Pages.Product
{   

    /// <summary>
    /// This is the UpdateModel class page. This will allow users to update some information about the games.
    /// </summary>
    public class UpdateModel : PageModel 
    {
       
        // creates a logger object
        private readonly ILogger<UpdateModel> _logger;

        /// <summary>
        /// Create a JsonFileLocationService object called ProductService with a getter.
        /// </summary>
        public JsonFileProductService ProductService { get; }


        /// <summary>
        /// Initialize the ProductService object.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UpdateModel(ILogger<UpdateModel> logger,JsonFileProductService productService)
        {
            ProductService = productService;
            _logger = logger;
        }


        /// <summary>
        /// Create a ProductService object called Product with a getter and setter.
        /// </summary>
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Create a string object called ModelId with a getter and setter.
        /// </summary>
        public string ModelId { get; set; }


        /// <summary>
        /// When called, this method will get the product that the user wants to update and display it on the page.
        /// OnGet will be called when the user clicks on the Update button.
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            ModelId = id;
            if (id == "temp")
            {
                Product = new ProductModel();
                //set only the id of the game to temp
                Product.Id = "temp";
            }
            else
            {
                Product = ProductService.GetProducts()
                    .FirstOrDefault(m => m.Id.Equals(id));
            }
        }

        /// <summary>
        /// Returns the correct field name if the product has not yet been created to add needed information.
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public string GetPlaceHolder(string FieldName)
        {
            if (ModelId == "temp")
            {
                switch (FieldName)
                {
                    case "Name":
                        return "Enter the name of the game.";
                    case "Maker":
                        return "Enter the maker of the game.";
                    case "Description":
                        return "Enter a description for the game.";
                    case "Image":
                        return "Enter the image url for the game.";
                    default: return "";

                }
            }

            //Returns the value of property of the game.
            return Product.GetType().GetProperty(FieldName)
                .GetValue(Product, null).ToString();
        }


        /// <summary>
        /// OnPost will allow the user to update the different fields and redirect the user to the Index page after it is done.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.Id == "temp")
            {
                ProductService.CreateData(Product);
            }
            else
            {
                ProductService.UpdateData(Product);
            }
            
            return RedirectToPage("./Index");
        }
    }
}