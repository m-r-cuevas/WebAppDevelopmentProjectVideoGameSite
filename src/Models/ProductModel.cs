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
        public string Id { get; set; }           //String Id of the product.
        // Added a property called "Name" -Ravi.
        public string Name { get; set; }         //String Name of the product.
        public string Maker { get; set; }        //String Maker of the product.
        
        [JsonPropertyName("img")]
        public string Image { get; set; }        //Image of the product.
        public string Url { get; set; }          //String Url of the image of the product.
        public string Title { get; set; }        //String Title of the product.
        public string Description { get; set; }  //String Description of the product.
        public int[] Ratings { get; set; }       //Integer array of ratings of the product.

        /// <summary>
        /// Returns string representation of product object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}