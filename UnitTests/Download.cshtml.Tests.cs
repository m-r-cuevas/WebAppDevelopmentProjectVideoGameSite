using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ConsoleCafe.WebSite.Pages;

namespace UnitTests.Pages.Download
{
    public class DownloadTests
    {
        #region TestSetup
        public static DownloadModel pageModel;

        /// <summary>
        /// Set up necessary for Download page tests and tests initializing page model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<DownloadModel>>();

            pageModel = new DownloadModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Test whether Download model is set up correctly on get
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