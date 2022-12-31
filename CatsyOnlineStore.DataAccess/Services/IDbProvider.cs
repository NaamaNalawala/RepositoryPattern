using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.DataAccess.Services
{
    public interface IDbProvider
    {
        Task<int> ExecuteAsync(string query, object[] param = null);

        Task<object> ExecuteScalarAsync(string query, object param = null);

        Task<IEnumerable<T>> QueryAsync<T>(string query, object param);
        Task<T> QueryFirstOrDefault<T>(string query, object param = null);
    }
}
