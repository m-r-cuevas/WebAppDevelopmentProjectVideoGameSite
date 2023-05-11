using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleCafe.WebSite.Models
{
    /// <summary>
    /// Product Class
    /// Product Model, Specifies the attributes of a game.
    /// </summary>
    public class ProductModel
    {
        //Required attribute is to specify that a property is required.

        //Id of the game is required.
        [Required(ErrorMessage = "Id field is required.")]
        public string Id { get; set; }

        //Name of the game is required.
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "100 character limit.")]
        public string Name { get; set; }

        //Maker of the game is required.
        [Required(ErrorMessage = "Maker is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "100 character limit.")]
        public string Maker { get; set; }        
        
        //Image of the game is required.
        [JsonPropertyName("img")]
        [Url]
        public string Image { get; set; }

        //String Url of the game.
        [Url]
        public string Url { get; set; }

        //String Title of the game - Not required as it not being displayed but has a maximum length of 100.
        [StringLength(100, MinimumLength = 1, ErrorMessage = "100 character limit.")]
        public string Title { get; set; }

        //String Description of the game is required.
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "200 charcter limit.")]
        public string Description { get; set; }

        //Enum product type.
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;

        //Integer array of ratings of the product - Not required.
        public int[] Ratings { get; set; }       

        /// <summary>
        /// Returns string representation of the game.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}