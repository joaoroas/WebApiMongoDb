using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiMongoDb.Settings;

namespace WebApiMongoDb.Data.Base
{
    public class MongoContext
    {
        public IMongoDatabase mongoDatabase;
        private readonly MongoClient _mongoClient;

        public MongoContext(IOptions<MongoDbSettings> mongoSettings, IOptions<ConnectionsStrings> connects)
        {
            var settings = MongoClientSettings.FromConnectionString(connects.Value.MONGO);
            settings.DirectConnection = mongoSettings.Value.UseDirectConnection;
#if !DEBUG
            settings.UseTls = mongoSettings.Value.UseTls;
#endif
            settings.ConnectTimeout = TimeSpan.FromSeconds(mongoSettings.Value.ConnectionTimeoutSeconds);
            _mongoClient = new(settings);
            mongoDatabase = _mongoClient.GetDatabase(mongoSettings.Value.Database);
        }
    }
}
