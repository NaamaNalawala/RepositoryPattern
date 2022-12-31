using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.DataAccess.Services
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<int> AddUpdateAsync(Order order);
        Task<IEnumerable<OrderProductView>> GetOrderWIthProductDetails();
    }
}
