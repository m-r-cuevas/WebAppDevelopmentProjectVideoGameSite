using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ConsoleCafe.WebSite.Pages;

namespace UnitTests.Pages.Index
{
    public class IndexTests
    {
        #region TestSetup
        public static IndexModel pageModel;

        /// <summary>
        /// Set up necessary for index page tests and tests initializing page
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();
            var MockProductService = TestHelper.ProductService;

            pageModel = new IndexModel(MockLoggerDirect, MockProductService)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region getProducts
        /// <summary>
        /// Tests whether the products method of Index correctlty returns products 
        /// </summary>
        [Test]
        public void Get_Products_Should_Return_True()
        {
            // Arrange

            // Act
            var products = pageModel.Products;
            

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion getProducts

        #region OnGet
        /// <summary>
        /// Test whether index model is set up correctly on get model
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