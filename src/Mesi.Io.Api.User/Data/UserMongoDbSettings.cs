namespace Mesi.Io.Api.User.Data
{
    public class UserMongoDbSettings : IUserMongoDbSettings
    {
        public string CollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public interface IUserMongoDbSettings
    {
        public string CollectionName { get; }
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}