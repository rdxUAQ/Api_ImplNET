
using ApiImpl.Models;

namespace ApiImpl.Interfaces
{
    public interface IProductsService
    {
        public Task<List<Product>?> getAllProductsAsync();
        public Task<Product?> getByIdAsync(string Id);
        public Task<Product> PostProductAsync(Product product);
        public Task<Product> UpdateProductAsync(string Id, Product product);

    }
    
}