using BarApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BarApp.Services
{
    public class BarService : IBarService
    {
        private readonly IMongoCollection<Bar> _BarsCollection;

        public BarService(
            IOptions<BarStoreDatabaseSettings> BarStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                BarStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                BarStoreDatabaseSettings.Value.DatabaseName);

            _BarsCollection = mongoDatabase.GetCollection<Bar>(
                BarStoreDatabaseSettings.Value.BarCollectionName);
        }

        public async Task<List<Bar>> GetAsync() =>
            await _BarsCollection.Find(_ => true).ToListAsync();

        public async Task<Bar?> GetAsync(string id) =>
            await _BarsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Bar newBar) =>
            await _BarsCollection.InsertOneAsync(newBar);

        public async Task UpdateAsync(string id, Bar updatedBar) =>
            await _BarsCollection.ReplaceOneAsync(x => x.Id == id, updatedBar);

        public async Task RemoveAsync(string id) =>
            await _BarsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
