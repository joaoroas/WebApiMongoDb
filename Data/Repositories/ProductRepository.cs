using MongoDB.Driver;
using MongoDB.Driver.Linq;
using WebApiMongoDb.Data.Base;
using WebApiMongoDb.Interfaces.Repositories;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.Data.Repositories
{
    public class ProductRepository : MongoRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MongoContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

            //return await Query.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateAsync(Product product)
        {
            await _collection.InsertOneAsync(product);

            if (String.IsNullOrEmpty(product.Id))
                return false;

            return true;
        }

        public async Task<bool> UpdateAsync(Product product, string id)
        {
            bool sucessUpdate = false;

            var result = await _collection.ReplaceOneAsync(x => x.Id == id, product);

            //var filter = Builders<Product>.Filter.Eq(x => x.Id, id);

            //var update = Builders<Product>.Update.Set(x => x.Nome, product.Nome);

            //var result = await _collection.UpdateOneAsync(filter, update);

            if (result.ModifiedCount == 1)
                sucessUpdate = true;

            return sucessUpdate;
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            bool sucessUpdate = false;

            var result = await _collection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount == 1)
                sucessUpdate = true;

            return sucessUpdate;
        }
    }
}
