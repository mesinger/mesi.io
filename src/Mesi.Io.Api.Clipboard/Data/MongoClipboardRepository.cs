using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mesi.Io.Api.Clipboard.Models;
using MongoDB.Driver;

namespace Mesi.Io.Api.Clipboard.Data
{
    public class MongoClipboardRepository : IClipboardRepository
    {
        private readonly IMongoCollection<MongoClipboardEntry> _collection;

        public MongoClipboardRepository(IClipboardMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<MongoClipboardEntry>(settings.CollectionName);
        }

        public void AddEntry(ClipboardEntry entry)
        {
            _collection.InsertOneAsync(entry.ToMongo());
        }

        public async Task<IEnumerable<ClipboardEntry>> GetAllByUserId(string userId)
        {
            var entries = await _collection.FindAsync(e => e.UserId == userId).Result.ToListAsync();
            return entries.Select(e => e.ToDomain());
        }
    }
}