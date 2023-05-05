using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ConsoleCafe.WebSite.Pages.Product;
using ConsoleCafe.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
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
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("1");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Fifa", pageModel.Product.Name);
        }
        #endregion OnGet

        #region OnPostAsync
        /// <summary>
        /// Test the delete functionality by added a fake product and then removing it.
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData();
            pageModel.Product.Name = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        /// <summary>
        /// Checks that invalid states are caught.
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
