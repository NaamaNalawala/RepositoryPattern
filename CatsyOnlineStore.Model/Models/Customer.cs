using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.Model.Models
{
    public  class Customer: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }

    }
}
