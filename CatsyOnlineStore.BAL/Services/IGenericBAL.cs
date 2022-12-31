using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.BAL.Services
{
    public interface IGenericBAL<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T model);
        Task<int> UpdateAsync(T model);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetByConditionAsync(string condition);
    }
}
