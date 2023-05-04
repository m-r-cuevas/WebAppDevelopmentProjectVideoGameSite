using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{   

    /// <summary>
    /// This is the UpdateModel class page. This will allow users to update a location.
    /// </summary>
    public class UpdateModel : PageModel 
    {

        //Create a JsonFileLocationService object called ProductService with a getter.
        public JsonFileProductService ProductService { get; }


        //Initialize the ProductService object.
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }




        //Create a ProductService object called Product with a getter and setter.
        [BindProperty]
        public ProductModel Product { get; set; }
        

        //When called, this method will get the product that the user wants to update and display it on the page.
        //OnGet will be called when the user clicks on the Update button.
        public void OnGet(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }
        

        //OnPost will allow the user to update the different fields and redirect the user to the Index page after it is done.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            ProductService.UpdateData(Product);
            
            return RedirectToPage("./Index");
        }
    }
}