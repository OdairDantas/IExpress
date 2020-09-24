namespace IExpress.Core.Config
{ 
    public static class MongoConfig
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
    }
}
