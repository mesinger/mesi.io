namespace Mesi.Io.Api.Clipboard.Data
{
    public class ClipboardMongoDbSettings : IClipboardMongoDbSettings
    {
        public string CollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public interface IClipboardMongoDbSettings
    {
        public string CollectionName { get; }
        public string ConnectionString { get; }
        public string DatabaseName { get; }
    }
}