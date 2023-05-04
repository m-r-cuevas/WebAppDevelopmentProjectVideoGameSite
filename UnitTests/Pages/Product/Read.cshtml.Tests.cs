

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    public class ReadTests
    {
        #region TestSetup
        public static ViewModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ViewModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
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

        [Test]
        public void GetRatings_No_Ratings_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            var ratings = pageModel.GetAverageRating("1");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(5, ratings);
        }
        #endregion OnGet
    }
}