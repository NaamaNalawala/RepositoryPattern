using CatsyOnlineStore.Model.Models;
using CatsyOnlineStore.DataAccess.Services;

namespace CatsyOnlineStore.DataAccess.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbProvider dbProvider): base(dbProvider)
        {
            
        }
        public Task<int> AddUpdateAsync(Customer customer)
        {
            string query = @$"
if exists(SELECT * from Customer where Id = '{customer.Id}')            
BEGIN            
 update Customer set Name='{customer.Name}', Email = '{customer.Email}', City ='{customer.City}', State = '{customer.State}', PostalCode = '{customer.PostalCode}', Contact = '{customer.Contact}', Password = '{customer.Password}' where Id = '{customer.Id}'  
End                    
else            
begin  
INSERT INTO [dbo].[customer]
           ([Name]
           ,[Email]
           ,[City]
           ,[PostalCode]
           ,[Contact]
           ,[State]
           , [Password])
     VALUES
           ('{customer.Name}'
           ,'{customer.Email}'
           ,'{customer.City}'
           ,'{customer.PostalCode}'
           ,'{customer.Contact}'
           ,'{customer.State}'
           ,'{customer.Password}') end";
            return dbProvider.ExecuteAsync(query);
        }

        public Task<Customer> Login(UserLoginEntity user)
        {
            string query = $"Select * from [dbo].[Customer] WHERE Email = '{user.UserName}' and Password = '{user.Password}'";
            return dbProvider.QueryFirstOrDefault<Customer>(query);
        }
        
    }
}
