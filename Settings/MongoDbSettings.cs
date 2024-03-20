namespace WebApiMongoDb.Settings
{
    public class MongoDbSettings
    {
        public string Database { get; set; }
        public int ConnectionTimeoutSeconds { get; set; }
        public bool UseDirectConnection { get; set; }
        public bool UseTls { get; set; }
    }
}
