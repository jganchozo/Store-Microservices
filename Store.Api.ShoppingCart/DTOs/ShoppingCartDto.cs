using System;
using System.Collections.Generic;

namespace Store.Api.ShoppingCart.DTOs
{
    public class ShoppingCartDto
    {
        public int ShoppingCartId { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<ShoppingCartDetailDto> ProductList { get; set; }
    }
}
