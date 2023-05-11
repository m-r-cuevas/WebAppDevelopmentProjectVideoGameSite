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
        private readonly ILogger<AboutModel> _logger; //Readonly ILogger object that allows logging.

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
