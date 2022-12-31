using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.BAL.Repositories
{
    public class ProductBAL : GenericBAL<Product>, IProductBAL
    {
        IProductRepository _productRepository;
        public ProductBAL(IGenericRepository<Product> genericRepository, IProductRepository productRepository) : base(genericRepository)
        {
            _productRepository = productRepository;
        }
        public new Task<int> AddAsync(Product product)
        {
            return _productRepository.AddUpdateAsync(product);
        }

        public new Task<int> UpdateAsync(Product product)
        {
            return _productRepository.AddUpdateAsync(product);
        }
    }
}
