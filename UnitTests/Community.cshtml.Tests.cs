using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ConsoleCafe.WebSite.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UnitTests.Pages.SignIn
{
    /// <summary>
    /// Unit tests for Sign in page functionality.
    /// </summary>
    public class SignInTests
    {
        #region TestSetup
        // Set up new CommunityModel instance
        public static CommunityModel pageModel;

        /// <summary>
        /// Set up necessary for SignIn page tests and tests initializing page model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<CommunityModel>>();

            pageModel = new CommunityModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Test whether SignIn model is set up correctly on get
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet


        /// <summary>
        /// Tests whether valid model state returns correct page
        /// </summary>
        [Test]
        public void OnPostAsync_Invalid_ModelState_Should_Return_Page()
        {
            // Arrange
            pageModel.ModelState.AddModelError("Email", "Email is required.");

            // Act
            var result = pageModel.OnPostAsync().GetAwaiter().GetResult();

            // Assert
            Assert.IsInstanceOf<PageResult>(result);
        }

        /// <summary>
        /// Tests email set/set methods with a valid email format
        /// </summary>
        [Test]
        public void Set_Email_Should_Return_True()
        {
            // Arrange
            var testEmail = "test@example.com";

            // Act
            pageModel.Email = testEmail;

            // Assert
            Assert.AreEqual(testEmail, pageModel.Email);
        }
    }
}