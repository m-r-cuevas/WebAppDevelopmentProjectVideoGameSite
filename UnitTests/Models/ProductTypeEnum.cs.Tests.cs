using NUnit.Framework;
using ConsoleCafe.WebSite.Models;
namespace UnitTests.Models
{
	/// <summary>
	/// Unit tests for ProductTypeEnum
	/// </summary>
	class ProductTypeEnumTests
	{
		#region DisplayName

		/// <summary>
		/// Tests that DisplayName returns valid string for 
		/// Enum value
		/// </summary>
		[Test]
		public void DisplayName_Should_Return_Valid_String()
		{
			// Arrange

			// Act
			string racing = ProductTypeEnum.Racing.DisplayName();
			string fps = ProductTypeEnum.FPS.DisplayName();
			string sports = ProductTypeEnum.Sports.DisplayName();


			// Assert
			Assert.AreEqual("Racing Game", racing);
			Assert.AreEqual("Sports Game", sports);
			Assert.AreEqual("First Person Shooter Game", fps);
		}

        #endregion DisplayName

        ///<summary>
        ///Test behaviour of DisplayName method for an out-of-range
        ///Enum value of the ProductTypeEnum. It does not require any setup.
        ///</summary>
        [Test]
        public void DisplayName_Enum_Out_Of_Range_Should_Return_Default()
        {
            // Arrange

            // Act
            var result = ProductTypeEnumExtensions.DisplayName((ProductTypeEnum)7);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}