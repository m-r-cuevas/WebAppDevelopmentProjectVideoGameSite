using NUnit.Framework;
using ConsoleCafe.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ConsoleCafe.WebSite.Models;

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
        public void OnGet_With_Id_Temp_Returns_Product_With_Temp_Id()
        {
            // Arrange
            var id = "temp";

            //Act
            pageModel.OnGet(id);

            //Assert
            Assert.AreEqual(pageModel.Product.Id, id);
        }

        /// <summary>
        /// Tests whether OnGet returns the correct product when given an valid id
        /// </summary>
        [Test]
        public void OnGet_With_Id_Valid_Returns_Product_With_Valid_Id()
        {
            // Arrange
            var expProductId = "2";

            //Act
            pageModel.OnGet(expProductId);

            //Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(expProductId, pageModel.Product.Id);
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

        /// <summary>
        /// The Unit test case to check if a Product is returned 
        /// When form is posted, and redirect to correct page
        /// </summary>
        [Test]
        public void OnPost_NewValidID_Should_Create_ValidProduct()
        {
            // Arrange
            pageModel.Product = new ConsoleCafe.WebSite.Models.ProductModel
            {
                Id = "temp",
                Name= "testing",
                Maker = "testing",
                Description = "testing",
                Image = "testing"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }
        #endregion OnPost

        #region GetPlaceHolder

        /// <summary>
        /// Test to check if the placeholder are returning the correct messages.
        /// </summary>
        [Test]
        public void GetPlaceHolder_TempModelId_Should_Return_CorrectPlaceHolder()
        {
            // Arrange
            pageModel.ModelId = "temp";
            string expectedPlaceHolderName = "Enter the name of the game.";
            string expectedPlaceHolderMaker = "Enter the maker of the game.";
            string expectedPlaceHolderDescription = "Enter a description for the game.";
            string expectedPlaceHolderProductType = "Enter a category for the game.";
            string expectedPlaceHolderImage = "Enter the image url for the game.";
            string expectedPlaceHolderRandom = "";


            // Act
            string actualPlaceHolderForName = pageModel.GetPlaceHolder("Name");
            string actualPlaceHolderForMaker = pageModel.GetPlaceHolder("Maker");
            string actualPlaceHolderForDescription = pageModel.GetPlaceHolder("Description");
            string actualPlaceHolderForProductType = pageModel.GetPlaceHolder("ProductType");
            string actualPlaceHolderForImage = pageModel.GetPlaceHolder("Image");
            string actualPlaceHolderForRandom = pageModel.GetPlaceHolder("Random");

            // Assert
            Assert.AreEqual(expectedPlaceHolderName, actualPlaceHolderForName);
            Assert.AreEqual(expectedPlaceHolderMaker, actualPlaceHolderForMaker);
            Assert.AreEqual(expectedPlaceHolderDescription, actualPlaceHolderForDescription);
            Assert.AreEqual(expectedPlaceHolderProductType, actualPlaceHolderForProductType);
            Assert.AreEqual(expectedPlaceHolderImage, actualPlaceHolderForImage);
            Assert.AreEqual(expectedPlaceHolderRandom, actualPlaceHolderForRandom);
        }

        /// <summary>
        /// Test to check if the placeholder are returning the correct messages.
        /// </summary>
        [Test]
        public void GetPlaceHolder_NotTempModelId_Should_Return_CorrectPropertyValue()
        {
            // Arrange
            pageModel.ModelId = "1";
            pageModel.Product = new ConsoleCafe.WebSite.Models.ProductModel
            {
                Id = "1",
                Name = "Test1",
                Maker = "Test1",
                Description = "Test1.",
                ProductType = "Test 1",
                Image = "Test1",
                Ratings = null
            };
            string expectedPropertyValue = pageModel.Product.Name;

            // Act
            string actualPropertyValue = pageModel.GetPlaceHolder("Name");

            // Assert
            Assert.AreEqual(expectedPropertyValue, actualPropertyValue);
        }

        /// <summary>
        /// Test to check invalid or null placeholder
        /// </summary>
        [Test]
        public void GetPlaceHolder_Invalid_PlaceHolder_Should_Return_EmptyString()
        {
            // Arrange
            pageModel.ModelId = "1";
            pageModel.Product = new ProductModel
            {
                Id = "1",
                Name = "Test1",
                Maker = null,
                Description = null,
                ProductType = "Test 1",
                Image = "Test1",
                Ratings = null
            };
            string expectedPropertyValue = "Empty";

            // Act
            string actualMakerValue = pageModel.GetPlaceHolder("Maker");
            string actualDescriptionValue = pageModel.GetPlaceHolder("Description");

            // Assert
            Assert.AreEqual(expectedPropertyValue, actualMakerValue);
            Assert.AreEqual(expectedPropertyValue, actualDescriptionValue);
        }

        #endregion GetPlaceHolder


    }
}