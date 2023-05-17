using NUnit.Framework;
using ConsoleCafe.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Unit test for Update page
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel; // Instance of UpdateModel

        /// <summary>
        /// Initializing method that creates an object of the UpdateModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<UpdateModel>>();

            pageModel = new UpdateModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
    }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// The Unit test case to check if the correct HTTP request ID is being retrieved
        /// And also check if its valid or not
        /// </summary>
        [Test]
        public void OnGet_With_Id_Temp_Returns_Location_With_Temp_Id()
        {
            // Arrange
            var id = "temp";

            //Act
            pageModel.OnGet(id);

            //Assert
            Assert.AreEqual(pageModel.Product.Id, id);
        }
        #endregion OnGet

        #region OnPost

        /// <summary>
        /// The Unit test case to check if a Product is returned 
        /// When form is posted, and redirect to correct page
        /// </summary>
        [Test]
        public void OnPost_ValidID_Should_Return_ValidProduct()
        {
            // Arrange
            pageModel.Product = new ConsoleCafe.WebSite.Models.ProductModel
            {
                Id = "9",
                Title = "testing",
                Description = "testing",
                Image = "testing"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        /// <summary>
        /// The Unit test case to check if no Product is returned 
        /// When invalid id is given
        /// </summary>
        [Test]
        public void OnPost_invalidID_Not_Valid_Page_Returned()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("test", "testing error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}