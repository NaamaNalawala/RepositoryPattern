using CatsyOnlineStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.DataAccess.Services
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<int> AddUpdateAsync(Customer customer);
        Task<Customer> Login(UserLoginEntity user);
    }
}
