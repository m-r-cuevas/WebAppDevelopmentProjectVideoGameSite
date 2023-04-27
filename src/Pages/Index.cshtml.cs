using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The IndexModel is the page model for the home page of the Contoso Crafts website.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The logger is used to log messages from the IndexModel class.
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Initializes a new instance of the IndexModel class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        /// <param name="productService">The product service instance to use.</param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// Gets the product service instance used by the IndexModel.
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Gets or sets the list of products retrieved from the product service.
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Called when the page is requested.
        /// </summary>
        public void OnGet()
        {
            // Get the list of products from the product service.
            Products = ProductService.GetProducts();
        }
    }
}