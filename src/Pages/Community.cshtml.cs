using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace ConsoleCafe.WebSite.Pages
{
    /// <summary>
    /// CommunityModel class
    /// For Sign-In page
    /// </summary>
    public class CommunityModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        //Readonly ILogger object that allows logging.
        private readonly ILogger<CommunityModel> _logger; 

        /// <summary>
        /// CommunityModel constructor
        /// initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public CommunityModel(ILogger<CommunityModel> logger)
        {
            _logger = logger;
        }

        // <summary>
        /// Placeholder for OnGet method
        /// </summary>
        public void OnGet()
        {
        }

        // <summary>
        /// This method sends an automated email using 
        /// MailKit library
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Console Cafe", "consolecafegaming@outlook.com"));
            message.To.Add(new MailboxAddress("", Email));
            message.Subject = "Welcome to Console Cafe Community";
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = "<h2>Welcome to the Social Community Hub!</h2>";

            bodyBuilder.HtmlBody += $"<p>Dear User,</p>";
            bodyBuilder.HtmlBody += "<p>We are excited to have you as a member of our community.</p>";
            bodyBuilder.HtmlBody += "<p>Join us in exploring new ideas, connecting with like-minded individuals, and engaging in meaningful conversations.</p>";

            bodyBuilder.HtmlBody += "<p><a href='https://5110teamconsolecafe.azurewebsites.net/'>Get Started</a></p>";

            bodyBuilder.HtmlBody += "<p>Thank you for joining us!</p>";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("consolecafegaming@outlook.com", "Console@111");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            return RedirectToPage("/Index");
        }
    }
}