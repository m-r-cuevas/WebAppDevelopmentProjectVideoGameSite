using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleCafe.WebSite.Models
{
    /// <summary>
    /// Product Class
    /// Product Model, Specifies the attributes of a product.
    /// </summary>
    public class ProductModel
    {
        //String Id of the product.
        public string Id { get; set; }           
        // Added a property called "Name".
        public string Name { get; set; }
        //String Maker of the product.
        public string Maker { get; set; }        
        
        [JsonPropertyName("img")]
        //Image of the product.
        public string Image { get; set; }
        //String Url of the image of the product.
        public string Url { get; set; }
        //String Title of the product.
        public string Title { get; set; }
        //String Description of the product.
        public string Description { get; set; }
        // Enum product type
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;  
        //Integer array of ratings of the product.
        public int[] Ratings { get; set; }       

        /// <summary>
        /// Returns string representation of product object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}