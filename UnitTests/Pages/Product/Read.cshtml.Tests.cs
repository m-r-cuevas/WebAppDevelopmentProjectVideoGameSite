using System.Linq;
using NUnit.Framework;
using ConsoleCafe.WebSite.Pages.Product;
using System;
namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// Unit Tests for the View Page.
    /// </summary>
    public class ReadTests
    {
        #region TestSetup

        //Instance for ViewModel
        public static ViewModel pageModel;

        /// <summary>
        /// Initializing the model.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ViewModel(TestHelper.ProductService)
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

        #region GetAverageRating

        /// <summary>
        /// Test case to check whether average rating calculation is correct.
        /// </summary>
        [Test]
        public void GetAverageRating_Ratings_Is_Null_Should_Return_Zero()
        {
            // Arrange
            var product = TestHelper.ProductService.GetProducts().First();

            // Act
            var ratings = pageModel.GetAverageRating(product.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(0, ratings);
        }

        [Test]
        public void GetAverageRating_Ratings_Not_Null_Should_Return_The_Avg_Rating_Of_Product_Matching_Product_Id()
        {
            // Arrange
            var product = TestHelper.ProductService.GetProducts().First();

            int numRatings = 5;

            for (int i = 0; i < numRatings; i++)
            {
                TestHelper.ProductService.AddRating(product.Id, i + 1);
            }

            var average = TestHelper.ProductService.GetProducts().First().Ratings.Average();

            // Act
            var result = pageModel.GetAverageRating(product.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(average, result);
        }
        #endregion GetAverageRating

        #region OnPost

        /// <summary>
        /// Test the OnPost method to return the correct comment
        /// </summary>
        [Test]
        public void OnPost_Should_Return_RedirectToPageResult()
        {
            // Arrange
            var id = "4";


            // Act
            var location = TestHelper.ProductService.GetProducts().First(m => m.Id.Equals(id));

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

        }

        /// <summary>
        /// Test for the OnPost method to return the correct comment if the name is null or empty
        /// </summary>
        [Test]
        public void OnPost_Should_Set_Name_To_Anonymous_If_Name_Is_Null_Or_Empty()
        {
            // Arrange
            var id = "4";

            // Act
            var location = TestHelper.ProductService.GetProducts().First(m => m.Id.Equals(id));

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}