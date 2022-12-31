using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.DataAccess.Services
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> AddUpdateAsync(Product product);
    }
}
