using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ConsoleCafe.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ConsoleCafe.WebSite.Services
{
    /// <summary>
    /// JsonFileProductService
    /// Accesses, adds and modifies products in Products.json
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// JsonFileProductService constructor
        /// Initializes the webHostEnvironment object
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Getter for WeHostEnironment
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Method that returns the path of the products.json file
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Gets all products from Products.json
        /// </summary>
        /// <returns>IEnumerable list of products</returns>
        public IEnumerable<ProductModel> GetProducts()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Add Rating
        /// 
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string productId, int rating)
        {
            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetProducts();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetProducts();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }
            // Update the data to the new passed in values
            productData.Name = data.Name;
            productData.Description = data.Description.Trim();
            productData.Url = data.Url;
            productData.Image = data.Image;

            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }
        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetProducts();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetProducts().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

        /// <summary>
        /// Create data to add to the system
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData(ProductModel product)
        {
            //Fetching the Id number of the last product and incrementing by one.
            var lastId = int.Parse(GetProducts().Last().Id);
            var newId = (lastId + 1).ToString();

            //Assinging the Id to the incremented one.
            product.Id= newId;

            // Retrieves the data from the json file
            var dataSet = GetProducts();

            //Add the new data to the end of the list
            var newDataSet = dataSet.Append(product);

            //Save the new data to the json file
            SaveData(newDataSet);

            //Returns the data entry that was just created
            return product;
        }
    }
}