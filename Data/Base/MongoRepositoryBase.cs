using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace WebApiMongoDb.Data.Base
{
    public class MongoRepositoryBase <TEntity> where TEntity : class
    {
        protected readonly MongoContext _context;
        protected readonly IMongoCollection<TEntity> _collection;

        protected IMongoQueryable<TEntity> Query => _collection.AsQueryable();

        public MongoRepositoryBase(MongoContext context, string? collectionName = null)
        {
            _context = context;
            _collection = context.mongoDatabase.GetCollection<TEntity>(collectionName ?? typeof(TEntity).Name);
        }

        protected IMongoCollection<TEntity> GetCollection<TEntity>(string? name = null)
            => _context.mongoDatabase.GetCollection<TEntity>(name ?? typeof(TEntity).Name);
    }
}
