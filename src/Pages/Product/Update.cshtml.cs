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
        private readonly ILogger<UpdateModel> _logger;

        //Create a JsonFileLocationService object called ProductService with a getter.
        public JsonFileProductService ProductService { get; }


        //Initialize the ProductService object.
        public UpdateModel(ILogger<UpdateModel> logger,JsonFileProductService productService)
        {
            ProductService = productService;
            _logger = logger;
        }


        //Create a ProductService object called Product with a getter and setter.
        [BindProperty]
        public ProductModel Product { get; set; }

        public string ModelId { get; set; }


        //When called, this method will get the product that the user wants to update and display it on the page.
        //OnGet will be called when the user clicks on the Update button.
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

        public string GetPlaceHolder(string FieldName)
        {
            if (ModelId == "temp")
            {
                switch (FieldName)
                {
                    case "Name":
                        return "Enter the name of the game.";
                    case "Description":
                        return "Enter a description for the game.";
                    case "Image":
                        return "Enter the image url for the game.";
                }
            }

            //Returns the value of property of the game.
            return Product.GetType().GetProperty(FieldName)
                .GetValue(Product, null).ToString();
        }


        //OnPost will allow the user to update the different fields and redirect the user to the Index page after it is done.
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