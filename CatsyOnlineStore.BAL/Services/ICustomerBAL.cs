using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.BAL.Services
{
    public interface ICustomerBAL: IGenericBAL<Customer>
    {
        Task<Customer> Login(UserLoginEntity user);
        new Task<int> AddAsync(Customer customer);
        new Task<int> UpdateAsync(Customer customer);
        new Task<IEnumerable<Customer>> GetAllAsync();
    }
}
