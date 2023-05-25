using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ConsoleCafe.WebSite.Pages.Product;
using ConsoleCafe.WebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Unit tests for the Delete page functionality.
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        public static DeleteModel pageModel;

        /// <summary>
        /// Checks that the DeleteModel initializes properly.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Initialize new DeleteModel
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Tests whether the correct product is returned with the OnGet method.
        /// </summary>
        [Test]
        public void OnGet_Should_Set_Product_To_Equal_User_Selected_Id()
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

        #region OnPost

        /// <summary>
        /// Test the delete functionality and checking the game is deleted.
        /// </summary>
        
        [Test]
        public void OnPost_Valid_Model_Delete_ProductData_And_RedirectToIndexPage()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();

            pageModel.OnGet(data.Id);

            // Act
            var result2 = pageModel.ProductService.GetProducts().Contains(data);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(false, result2);
        }

        /// <summary>
        /// Tests the ModelState is valid to return correct page.
        /// </summary>
        [Test]
        public void OnPost_Valid_Model_Returns_Page()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();

            // Set the model to a valid model
            pageModel.Product = data;

            // Ensure model state is valid
            pageModel.ModelState.Clear();

            // Act
            var result = pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.IsInstanceOf<PageResult>(result);
        }

        /// <summary>
        /// The Unit test case to check if and error page is returned
        /// when model is invalid
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "bogus",
                Name = "bogus",
                Description = "bogus",
                Url = "bogus",
                Image = "bogus"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}