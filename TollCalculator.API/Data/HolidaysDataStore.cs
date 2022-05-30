using JsonFlatFileDataStore;

namespace TollCalculator.API.Data
{
    public class HolidaysDataStore : IHolidaysDataStore
    {
        private DataStore _dataStore;
        public HolidaysDataStore()
        {
            _dataStore = new DataStore(Path.Join(AppContext.BaseDirectory, "Data\\holidays.json"));
        }

        public IEnumerable<T> Collection<T>(string name) where T : class
        {
            return _dataStore.GetCollection<T>(name).AsQueryable();
        }

        public async Task InsertOneAsync<T>(string name, T obj) where T : class
        {
            var collection = _dataStore.GetCollection<T>(name);
            await collection.InsertOneAsync(obj);
        }
    }
}
