using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ConsoleCafe.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        public static IndexModel pageModel;

        /// <summary>
        /// Tests whether index initializes correctly. 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // initialize new IndexModel
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// tests if valid products are return and if a list is properly created.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
   

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}