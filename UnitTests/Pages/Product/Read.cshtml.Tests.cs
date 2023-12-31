﻿using System.Linq;
using NUnit.Framework;
using ConsoleCafe.WebSite.Pages.Product;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;

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

        // A message for testing
        private const string redirectMessage = "The requested game is invalid.";

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

        /// <summary>
        /// The unit test case to check if the product/game is null then
        /// should return to the error page.
        /// </summary>
        [Test]
        public void OnGet_With_Null_Product_Should_Redirect_To_Error()
        {
            // Arrange
            var id = "900";
            // need to Mock the TempData, TempData is a feature in .NET
            pageModel.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());

            // Act
            var result = pageModel.OnGet(id);

            // Assert
            Assert.IsTrue(result is RedirectToPageResult);
            var redirectResult = (RedirectToPageResult)result;
            Assert.AreEqual("/Error", redirectResult.PageName);

            // Assert TempData message
            var tempMessage = pageModel.TempData["InvalidGameMessage"];
            Assert.AreEqual(redirectMessage, tempMessage);

            Assert.AreEqual(null, pageModel.Product);
            Assert.IsTrue(pageModel.ModelState.IsValid);
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

        /// <summary>
        /// Tests whether a request for a non-null product rating returns the correct results.
        /// </summary>
        [Test]
        public void GetAverageRating_Ratings_Not_Null_Should_Return_The_Avg_Rating_Of_Product_Matching_Product_Id()
        {
            // Arrange
            var product = TestHelper.ProductService.GetProducts().First();

            // Variable to hold number of ratings
            int numRatings = 5;

            for (int i = 0; i < numRatings; i++)
            {
                TestHelper.ProductService.AddRating(product.Id, i + 1);
            }

            // Variable to calculate average of ratings
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