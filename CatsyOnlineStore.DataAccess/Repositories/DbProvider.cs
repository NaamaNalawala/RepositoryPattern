using Dapper;
using CatsyOnlineStore.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CatsyOnlineStore.DataAccess.Repositories
{
    public class DbProvider : IDbProvider, IDisposable
    {
        private readonly IDbConnection connection;
        public DbProvider(IDbConnection connection)
        {
            this.connection = connection;
            //this.connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=catsyDb;User Id=sa;Password=sa;");
            try
            {
                this.connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null)
        {
            return await connection.QueryAsync<T>(query, param);
        }
        public async Task<T> QueryFirstOrDefault<T>(string query, object param = null)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(query, param);
        }
        public async Task<int> ExecuteAsync(string query, object[] param)
        {
            return await connection.ExecuteAsync(query, param);
        }

        public Task<object> ExecuteScalarAsync(string query, object param = null)
        {
            return connection.ExecuteScalarAsync(query, param);
        }

        public void Dispose()
        {
            this.connection.Close();
            this.connection.Dispose();
        }
    }
}
