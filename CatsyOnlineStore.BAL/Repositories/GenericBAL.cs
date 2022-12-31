
using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.DataAccess.Services;

namespace CatsyOnlineStore.BAL.Repositories
{
    public class GenericBAL<T> : IGenericBAL<T>
    {
        IGenericRepository<T> _genericRepository;
        public GenericBAL(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Task<int> AddAsync(T model)
        {
            return _genericRepository.AddUpdateAsync();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _genericRepository.GetAllAsync();
        }

        public Task<IEnumerable<T>> GetByConditionAsync(string condition)
        {
            return _genericRepository.GetByConditionAsync(condition);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _genericRepository.GetByIdAsync(id);
        }

        public Task<int> UpdateAsync(T model)
        {
            return _genericRepository.AddUpdateAsync();
        }
    }
}
