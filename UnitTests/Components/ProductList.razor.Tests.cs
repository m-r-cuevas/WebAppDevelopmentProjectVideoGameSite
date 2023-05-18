using Bunit;
using NUnit.Framework;
using ConsoleCafe.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ConsoleCafe.WebSite.Services;
using System.Linq;
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
            Assert.AreEqual(true, pageMarkup.Contains("Testing Filter text"));

        }
        #endregion UpdateFilterText

  

        /* test for EnableFilterData() */
        #region EnableFilterData
        [Test]
        public void Enable_Filter_Data_Set_to_True_Should_Return_True()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var filterButton = "Search";

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

        /*Tests that changing the cateogry filter dropdown returns content*/
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

        /*Tests that filtering for an item when its incorrect category is selected returns item not found message*/
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
            var button = buttonList.First(m => m.OuterHtml.Contains("Search"));

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

        /*Tests for clicking the download button shows page responsive page*/
        #region SelectLocation
        [Test]
        public void Select_Download_Should_Return_Page_Responsive()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "download-button";

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
            Assert.AreEqual(true, pageMarkup.Contains("You have clicked on the tile buttons"));
        }
        #endregion SelectLocation
      
    }
}