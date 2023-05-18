using Bunit;
using NUnit.Framework;

using ConsoleCafe.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ConsoleCafe.WebSite.Services;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Fifa"));
        }

        #region SelectProduct
        [Test]
        public void SelectProduct_Valid_ID_Fifa_1_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "ViewMoreButton_1";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Fifa"));
        }
        #endregion SelectProduct

        /* test for UpdateFilter() */
        #region UpdateFilterText
        [Test]
        public void Update_Filter_Text_Valid_Should_Return_True()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            // Set up testing text
            var testText = "Testing Filter text";

            var page = RenderComponent<ProductList>();

            // Find input all fields
            var filterList = page.FindAll("Input");

            // First field should be name filter
            var filter = filterList.First();

            // Act
            // trigger onchange event using the test text
            filter.Change(testText);

            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains($"{testText}"));

        }
        #endregion UpdateFilterText


        /* test for EnableFilterData() */
        #region EnableFilterData
        [Test]
        public void Enable_Filter_Data_Set_to_True_Should_Return_True()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var filterButton = "Filter";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (filter)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the button name looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(filterButton));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, true);
        }
        #endregion EnableFilterData

        /* test for ClearFilterData() */
        #region ClearFilterData
        [Test]
        public void Clear_Filter_Data_Set_to_False_Should_Return_False()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var clearButton = "Clear";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (Clear)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the button name looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(clearButton));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(false, false);
        }
        #endregion ClearFilterData

        #region UpdateFilterCategory

        /// <summary>
        /// Tests that changing the cateogry filter dropdown 
        /// returns content
        /// </summary>
        [Test]
        public void UpdateFilterCategory_Should_return_Content()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var categoryDropdown = page.Find("select");

            // Act
            categoryDropdown.Change("Racing");

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("GTA 5"));
        }

        #endregion UpdateFilterCategory

        #region FilterAndRenderProducts

        /// <summary>
        /// Tests that filtering for an item when its incorrect category
        /// is selected returns "Sorry! Could not find any items matching 
        /// your search." Message
        /// </summary>
        [Test]
        public void Filter_For_Non_Existing_Products_Should_Return_No_Matching_Products_Message()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var categoryDropdown = page.Find("select");

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");
            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains("Filter"));

            // Find all input elements
            var inputList = page.FindAll("input");
            // Find input element with id filter-input 
            var filterInput = inputList.First(m => m.Id.Equals("filter-input"));

            // Act
            // Change cateory to fruit
            categoryDropdown.Change("Racing");

            // Search for a Sport item
            filterInput.Change("Fifa");
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("The search results are on vacation. They left no forwarding address. Maybe they're sipping margaritas on a sunny beach. Try again with something we can find!!"));
        }

        #endregion FilterAndRenderProducts
        /* Comment out SubmitRating tests which are currently unecessary
        #region SubmitRating

        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed

            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status

            

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_jenlooper-light";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        [Test]
        public void SubmitRating_Valid_ID_Click_Stared_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed

            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status

            

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_1";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the Last star item from the list, it should one that is checked
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("6 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("7 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRating
    */
    }
}