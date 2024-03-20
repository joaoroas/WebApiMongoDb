using WebApiMongoDb.Models;

namespace WebApiMongoDb.Interfaces.Services
{
    public interface IProductService
    {
        Task<bool> CreateAsync(Product product);
        Task<bool> DeleteByIdAsync(string id);
        Task<List<Product>> GetAsync();
        Task<Product> GetByIdAsync(string id);
        Task<bool> UpdateAsync(Product product, string id);
    }
}