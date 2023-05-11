using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ConsoleCafe.WebSite.Pages
{
    /// <summary>
    /// SignInModel class
    /// For Sign-In page
    /// </summary>
    public class SignInModel : PageModel
    {
        private readonly ILogger<SignInModel> _logger; //Readonly ILogger object that allows logging.

        /// <summary>
        /// SignInModel constructor
        /// initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public SignInModel(ILogger<SignInModel> logger)
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