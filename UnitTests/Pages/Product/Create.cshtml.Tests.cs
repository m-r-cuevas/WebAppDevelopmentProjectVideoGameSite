using NUnit.Framework;
using ConsoleCafe.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Create
{
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup
        #region OnGet
        [Test]
		public void OnGet_Returns_Product_With_Id()
		{
			// Arrange
			



			// Act
            // Since the id is a string, for every new card that is created 1 is concatenated
            // to the id. which is why the new product should be 91 since the last productId is 9
			pageModel.OnGet("91");

			// Assert
			Assert.AreEqual(true, pageModel.ModelState.IsValid);
			Assert.AreEqual(pageModel.Product.Id, "91");

		}
		#endregion OnGet


	}
}