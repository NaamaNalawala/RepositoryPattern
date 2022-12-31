namespace CatsyOnlineStore.DataAccess.Services
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddUpdateAsync(string query);
        Task<int> AddUpdateAsync();
        Task<T> GetByIdAsync(int idd);
        Task<IEnumerable<T>> GetByConditionAsync(string condition);
    }
}
