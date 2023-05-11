using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ConsoleCafe.WebSite.Pages.Product;
using ConsoleCafe.WebSite.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region UpdateData

        /// <summary>
        /// Tests whether the UpdateData method returns null when provided with a null ProductData object
        /// </summary>
        [Test]
        public void UpdateData_ProductData_IsNull()
        {
            // Arrange
            var product = new ProductModel();

            // Act
            var result = TestHelper.ProductService.UpdateData(product);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests whether the UpdateData method returns a UpdateData object when provided with a valid ProductData object
        /// </summary>
        [Test]
        public void UpdateData_ProductData_IsNotNull_Return_ProductData()
        {
            // Arrange
            var product = TestHelper.ProductService.GetProducts().First();

            product.Name = "Fifa";

            // Act
            var result = TestHelper.ProductService.UpdateData(product);

            // Assert
            Assert.AreEqual(product.Name, result.Name);
        }

        #endregion UpdateData

        #region DeleteProduct

        /// <summary>
        /// Tests whether the method deletes a product and returns the deleted product.
        /// </summary>
        [Test]
        public void DeleteProduct_ProductExists_ProductDeleted()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();

            // Act
            var result = TestHelper.ProductService.DeleteData(data.Id);

            // Assert
            Assert.AreEqual(data.Id, result.Id);
        }
        #endregion DeleteProduct

        #region AddRating
        /// <summary>
        /// Tests whether an invalid product id returns false.
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
         
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test if a method to catch ratings that are too low works. Should return false.
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Valid_Rating_InValid_Too_Low_Should_Return_False()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetProducts().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);
            var dataNewList = TestHelper.ProductService.GetProducts().First();

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Test whether method to prevent too high ratings works. Should return false.
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Valid_Rating_InValid_Too_High_Should_Return_False()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetProducts().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 6);
            var dataNewList = TestHelper.ProductService.GetProducts().First();

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test whether an invalid product can be used. Should return false.
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Not_Found_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("Test-Product-Does-Not-Exist", 5);
            var dataNewList = TestHelper.ProductService.GetProducts().First();

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test whether a valid rating can be added to a valid product. Should return true.
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetProducts().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetProducts().First();
    
            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// Test whether a new ratings array is added when a valid rating is added to a valid product that
        /// currently has null ratings. Should return true. For some reason I cannot get this method to 
        /// cover the create new array for ratings portion of the AddRating Method. 
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Ratings_Empty_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetProducts().Last();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 4);

            // Assert
            Assert.AreEqual(true, result);
        }
        /// <summary>
        /// Test whether null data passed to UpdateDate method returns null
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Null_Data_Should_Return_True()
        {
            // Arrange
            //var newEntry = TestHelper.ProductService.CreateData();
            //var emptyProduct = TestHelper.ProductService.GetProducts().Last();

            // Act
            //var result = TestHelper.ProductService.UpdateData(emptyProduct);

            

            // Assert
            //Assert.AreEqual(null, result);
        }
        #endregion AddRating

    }
}
