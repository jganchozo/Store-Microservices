using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.Model
{
    public class ShoppingCartSession
    {
        public int ShoppingCartSessionId { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<ShoppingCartSessionDetail> DetailList { get; set; }
    }
}
