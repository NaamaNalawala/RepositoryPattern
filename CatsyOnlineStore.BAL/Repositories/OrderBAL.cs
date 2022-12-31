using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.BAL.Repositories
{
    public class OrderBAL : GenericBAL<Order>, IOrderBAL
    {
        IGenericRepository<Order> _genericRepository;
        IOrderRepository _orderRepository;
        public OrderBAL(IGenericRepository<Order> genericRepository, IOrderRepository orderRepository) : base(genericRepository)
        {
            _orderRepository = orderRepository;
            _genericRepository = genericRepository; 
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(string customerId)
        {
            string condition = $"CustomerId = '{customerId}'";
            return await _genericRepository.GetByConditionAsync(condition);
        }
        public async Task<IEnumerable<OrderProductView>> GetOrderWIthProductDetails()
        {
            return await _orderRepository.GetOrderWIthProductDetails();
        }
        public async new Task<int> AddAsync(Order order)
        {
            return await _orderRepository.AddUpdateAsync(order);
        }
        public async new Task<int> UpdateAsync(Order order)
        {
            return await _orderRepository.AddUpdateAsync(order);
        }
    }
}
