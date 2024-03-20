using WebApiMongoDb.Data.Base;
using WebApiMongoDb.Data.Repositories;
using WebApiMongoDb.Interfaces.Repositories;
using WebApiMongoDb.Interfaces.Services;
using WebApiMongoDb.Services;
using WebApiMongoDb.Settings;

namespace WebApiMongoDb.Extensions
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder RegisterDepedencies(this IHostBuilder builder)
        {
            return builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MongoContext>();
                services.AddSingleton<IProductRepository, ProductRepository>();
                services.AddSingleton<IProductService, ProductService>();

            });
        }

        public static IHostBuilder RegisterSettings(this IHostBuilder builder)
        {
            return builder.ConfigureServices((hostContext, services) =>
            {
                services.AddOptions<ConnectionsStrings>().BindConfiguration("ConnectionsStrings");
                services.AddOptions<MongoDbSettings>().BindConfiguration("MongoDb");
                //services.AddOptions<Application>().BindConfiguration("Application");
            });
        }
    }
}
