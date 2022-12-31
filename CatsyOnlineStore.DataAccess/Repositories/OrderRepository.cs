using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDbProvider dbProvider): base(dbProvider)
        {

        }
        public Task<int> AddUpdateAsync(Order order)
        {
            string query = @$"
if exists(SELECT * from [dbo].[order] where Id = '{order.Id}')            
BEGIN            
 update [dbo].[order] set CustomerId = '{order.CustomerId}', ProductId = '{order.ProductId}', Quantity = {order.Quantity}, Price = {order.Price} where Id = '{order.Id}'  
End                    
else            
begin  
INSERT INTO [dbo].[order]
           ([CustomerId]
           ,[ProductId]
           ,[Quantity]
           ,[Price]
           ,[CreatedAt])
     VALUES
           ('{order.CustomerId}'
           ,'{order.ProductId}'
           ,{order.Quantity}
           ,{order.Price}
            ,'{order.CreatedAt}') end";
            return dbProvider.ExecuteAsync(query);
        }
        public Task<IEnumerable<OrderProductView>> GetOrderWIthProductDetails()
        {
            string query = @"Select o.Id, o.ProductId, o.CustomerId, o.Quantity, o.Price, o.CreatedAt, p.Name as ProductName, p.BrandName, p.Description as ProductDescription from [dbo].[order] o
                INNER JOIN Product p
                ON o.ProductId = p.Id
                ";
            return dbProvider.QueryAsync<OrderProductView>(query, null);

        }
    }
}
