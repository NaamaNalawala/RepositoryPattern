using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public IDbProvider dbProvider;
        public GenericRepository(IDbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }
        public Task<int> AddUpdateAsync()
        {
            return dbProvider.ExecuteAsync("");
        }
        public Task<int> AddUpdateAsync(string query)
        {
            return dbProvider.ExecuteAsync(query);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            string query = $"Select * from [dbo].[{typeof(T).Name}]";
            return dbProvider.QueryAsync<T>(query, null);
        }

        public Task<T> GetByIdAsync(int idd)
        {
            string query = $"Select * from [dbo].[{typeof(T).Name}] where Id = @id";
            return dbProvider.QueryFirstOrDefault<T>(query, new { id = idd });
        }
        public Task<IEnumerable<T>> GetByConditionAsync(string condition)
        {
            string query = $"Select * from [dbo].[{typeof(T).Name}] where {condition}";
            return dbProvider.QueryAsync<T>(query, null);
        }

    }
}
