using ApiImpl.Interfaces;
using ApiImpl.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace ApiImpl.Services
{
    public class ProductsService : IProductsService
    {
        private readonly LoggerService _logger;
        private readonly static string basePath = Directory.GetCurrentDirectory();
        private readonly static string productsPath = Path.Combine(basePath, "data", "Products.json");
        private readonly string jsonProducts = File.ReadAllText(productsPath);

        public ProductsService(LoggerService loggerService)
        {
            _logger = loggerService;
        }

        // Add service methods and properties here
        public async Task<List<Product>?> getAllProductsAsync()
        {
            List<Product>? result = new List<Product>();

            //read json file for products
            try
            {
                
                 result = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error reading products JSON file.", ex);

            }

            if (!result.Any()) return null;

            await Task.Delay(2000);

            return result;

        }

        public async Task<Product?> getByIdAsync(string Id)
        {

            List<Product>? prods = new List<Product>();
            Product? result = new Product();

            try
            {

                result = JsonConvert.DeserializeObject<List<Product>>(jsonProducts) ?
                        .FirstOrDefault(i => i.Id == Id);


            }
            catch (Exception ex)
            {
                _logger.LogError("Error reading products JSON file.", ex);

            }

            await Task.Delay(2000);

            return result;
        }
        public async Task<Product> UpdateProductAsync(string Id, Product updatedProduct)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
            var product = products?.FirstOrDefault(p => p.Id == Id);

            try
            {

                product = products?.FirstOrDefault(i => i.Id == Id);


            }
            catch (Exception ex)
            {
                _logger.LogError("Error reading products JSON file.", ex);

            }

            if (product == null)
            {
                return null;
                
            }

            //set new values
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Stock = updatedProduct.Stock;


            try
            {

                string updateJson = JsonConvert.SerializeObject(jsonProducts, Formatting.Indented);

                await File.WriteAllTextAsync(productsPath, updateJson);


            }
            catch (Exception ex)
            {
                _logger.LogError("Error writing products JSON file.", ex);

            }


            await Task.Delay(2000);
            return  JsonConvert.DeserializeObject<List<Product>>(jsonProducts).FirstOrDefault(p => p.Id == Id);

        }

        public async Task<Product> PostProductAsync(Product product)
        {
            throw new NotImplementedException();
        }


    }
}