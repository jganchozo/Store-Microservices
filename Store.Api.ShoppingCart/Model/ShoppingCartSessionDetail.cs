using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.Model
{
    public class ShoppingCartSessionDetail
    {
        public int ShoppingCartSessionDetailId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string SelectedProduct { get; set; }
        public int ShoppingCartSessionId { get; set; }
        public ShoppingCartSession CartSession { get; set; }
    }
}
