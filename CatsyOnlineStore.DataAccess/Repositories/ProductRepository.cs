using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IDbProvider dbProvider) : base(dbProvider)
        {

        }
        public Task<int> AddUpdateAsync(Product product)
        {
            string query = @$"
if exists(SELECT * from Product where Id = '{product.Id}')            
BEGIN            
 update Product set Name='{product.Name}', BrandName = '{product.BrandName}', Description = '{product.Description}' where Id = '{product.Id}'  
End                    
else            
begin  
INSERT INTO [dbo].[product]
           ([Name]
           ,[BrandName]
           ,[Description]
           ,[CreatedAt])
     VALUES
           ('{product.Name}'
           ,'{product.BrandName}'
           ,'{product.Description}'
           ,'{product.CreatedAt}') end";
            return dbProvider.ExecuteAsync(query);
        }
    }
}
