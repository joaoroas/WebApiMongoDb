using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiMongoDb.Data;
using WebApiMongoDb.Interfaces.Repositories;
using WebApiMongoDb.Interfaces.Services;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> CreateAsync(Product product)
        {
            return await _repository.CreateAsync(product);
        }

        public async Task<bool> UpdateAsync(Product product, string id)
        {
            return await _repository.UpdateAsync(product, id);
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
