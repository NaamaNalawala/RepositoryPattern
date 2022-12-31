using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsyOnlineStore.Model.Models
{
    public class JWTTokenEntity
    {
        public string Issuer { set; get; }
        public string Secret { set; get; }
        public string Audience { set; get; }
        public string AccessTokenExpiration { set; get; }
        public string RefreshTokenExpiration { set; get; }

    }
}
