using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ConsoleCafe.WebSite.Pages;

namespace UnitTests.Pages.SignIn
{
    public class SignInTests
    {
        #region TestSetup
        public static SignInModel pageModel;

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