﻿using System;

namespace Store.Api.ShoppingCart.DTOs
{
    public class ShoppingCartDetailDto
    {
        public Guid? BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}
