using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ConsoleCafe.WebSite.Pages
{
    /// <summary>
    /// AboutModel class
    /// For About Us page
    /// </summary>
    public class AboutModel : PageModel
    {
        //Readonly ILogger object that allows logging.
        private readonly ILogger<AboutModel> _logger; 

        /// <summary>
        /// AboutModel constructor
        /// initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        // <summary>
        /// Placeholder for OnGet method
        /// </summary>
        public void OnGet()
        {
        }
    }
}
