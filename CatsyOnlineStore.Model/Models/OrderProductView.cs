using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.Model.Models
{
    public class OrderProductView:Order
    {
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ProductDescription { get; set; }
    }
}
