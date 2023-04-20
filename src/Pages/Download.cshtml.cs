using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly ILogger<DownloadModel> _logger;

        public DownloadModel(ILogger<DownloadModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
