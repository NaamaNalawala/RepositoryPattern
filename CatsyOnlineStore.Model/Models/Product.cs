using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.Model.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
    }
}
