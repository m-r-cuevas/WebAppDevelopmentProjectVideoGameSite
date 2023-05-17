using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ConsoleCafe.WebSite.Pages.Product;
using ConsoleCafe.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Create
{
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel createModel;
        private JsonFileProductService _productService;
        private Mock<ILogger<CreateModel>> _mockLogger;

        [SetUp]
        public void TestInitialize()
        {
            _mockLogger = new Mock<ILogger<CreateModel>>();
            _productService = TestHelper.ProductService;
            createModel = new CreateModel(_mockLogger.Object, _productService);
        }

        #endregion TestSetup
        #region OnGet
        [Test]
		public void OnGet_ReturnsRedirectToPageResult()
		{
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