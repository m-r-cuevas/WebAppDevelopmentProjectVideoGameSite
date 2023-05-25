using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ConsoleCafe.WebSite.Pages;

namespace UnitTests.Pages.SignIn
{
    /// <summary>
    /// Unit tests for Sign in page functionality.
    /// </summary>
    public class SignInTests
    {
        #region TestSetup
        // Set up new SignInModel instance
        public static SignInModel pageModel;

        /// <summary>
        /// Set up necessary for SignIn page tests and tests initializing page model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<SignInModel>>();

            pageModel = new SignInModel(MockLoggerDirect)
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
    }
}