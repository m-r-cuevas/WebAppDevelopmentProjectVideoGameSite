using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The DownloadModel is the page model for the download page of the Contoso Crafts website.
    /// </summary>
    public class DownloadModel : PageModel
    {
        /// <summary>
        /// The logger is used to log messages from the DownloadModel class.
        /// </summary>
        private readonly ILogger<DownloadModel> _logger;

        /// <summary>
        /// Initializes a new instance of the DownloadModel class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        public DownloadModel(ILogger<DownloadModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called when the page is requested.
        /// </summary>
        public void OnGet()
        {
            // This method is intentionally left blank.
        }
    }
}