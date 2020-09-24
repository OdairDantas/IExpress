using IExpress.Core.Config;
using MongoDB.Driver;

namespace IExpress.Core.Data
{
    public class MongoDbContext<TEntity> where TEntity : class
    {
        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {

            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConfig.ConnectionString));
            if (MongoConfig.IsSSL)
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase(MongoConfig.DatabaseName);

        }

        public IMongoCollection<TEntity> Collection
        {
            get
            {
                return _database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }
    }
}
