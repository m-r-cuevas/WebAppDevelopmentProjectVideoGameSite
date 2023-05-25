using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ConsoleCafe.WebSite.Pages
{
    /// <summary>
    /// PrivacyModel class
    /// For privacy page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        //Readonly ILogger object that allows logging.
        private readonly ILogger<PrivacyModel> _logger; 

        /// <summary>
        /// PrivacyModel constructor
        /// initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
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
