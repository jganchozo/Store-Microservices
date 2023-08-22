using Microsoft.EntityFrameworkCore;
using Store.Api.ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.ShoppingCart.Persistence
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options) { }

        public virtual DbSet<ShoppingCartSession> ShoppingCartSession { get; set; }
        public virtual DbSet<ShoppingCartSessionDetail> ShoppingCartSessionDetail { get; set; }
    }
}
