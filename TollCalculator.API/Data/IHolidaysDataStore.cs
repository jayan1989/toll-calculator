namespace TollCalculator.API.Data
{
    public interface IHolidaysDataStore
    {
        IEnumerable<T> Collection<T>(string name) where T : class;
        Task InsertOneAsync<T>(string name, T obj) where T : class;
    }
}
