using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ConsoleCafe.WebSite.Pages;
using ConsoleCafe.WebSite.Pages.Product;
using System.Linq;

namespace UnitTests.Pages.Download
{
    /// <summary>
    /// Unit tests for Download page functionality.
    /// </summary>
    public class DownloadTests
    {
        #region TestSetup
        // Set up new Download Model instance
        public static DownloadModel pageModel;

        /// <summary>
        /// Set up necessary for Download page tests and tests initializing page model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DownloadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test case to check if the game selected is correct.
        /// </summary>
        [Test]
        public void OnGet_Should_Select_Matching_Id()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();

            // Act
            pageModel.OnGet(data.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(data.Id, pageModel.Product.Id);
        }
        #endregion OnGet

    }
}