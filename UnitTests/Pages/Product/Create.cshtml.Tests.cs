using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ConsoleCafe.WebSite.Pages.Product;
using ConsoleCafe.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Unit tests for the Create page functionality. 
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        // Set up a new CreateModel instance
        public static CreateModel createModel;
        // Set up new JsonFileProductService instance
        private JsonFileProductService _productService;
        // Set up new mock logger instance
        private Mock<ILogger<CreateModel>> _mockLogger;

        /// <summary>
        /// Tests whether the create model intializes correctly
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            _mockLogger = new Mock<ILogger<CreateModel>>();
            _productService = TestHelper.ProductService;
            createModel = new CreateModel(_mockLogger.Object, _productService);
        }

        #endregion TestSetup
        #region OnGet
        /// <summary>
        /// Tests whether the correct page results are return by OnGet method.
        /// </summary>
        [Test]
		public void OnGet_ReturnsRedirectToPageResult()
		{
            // Arrange
            string expId = "temp";
			

			// Act
			var result = createModel.OnGet() as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Update", result.PageName);
            Assert.AreEqual(expId, result.RouteValues["Id"]);
            Assert.AreEqual(true, createModel.ModelState.IsValid);
		}

        ///<summary>
        ///Testing the Getter.
        ///</summary>
        [Test]
        public void CreateModel_Constructor_SetsProductServiceProperty()
        {
            // Arrange & Act
            var createModel = new CreateModel(_mockLogger.Object, _productService);

            //Assert
            Assert.AreEqual(_productService, createModel.ProductService);
        }
		#endregion OnGet
	}
}