using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class ViewModel : PageModel
    {
        private readonly ILogger<ViewModel> _logger;

        public ViewModel(ILogger<ViewModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
