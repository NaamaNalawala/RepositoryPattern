using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.BAL.Services
{
    public interface IOrderBAL : IGenericBAL<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerId(string customerId);
        Task<IEnumerable<OrderProductView>> GetOrderWIthProductDetails();
        new Task<int> AddAsync(Order order);
        new Task<int> UpdateAsync(Order order);
    }
}
