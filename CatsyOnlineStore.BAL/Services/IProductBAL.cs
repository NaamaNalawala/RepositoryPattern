using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.BAL.Services
{
    public interface IProductBAL: IGenericBAL<Product>
    {
        new Task<int> AddAsync(Product product);
        new Task<int> UpdateAsync(Product product);
    }
}
