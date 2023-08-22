using Microsoft.EntityFrameworkCore;
using Store.Api.Book.Model;

namespace Store.Api.Book.Persistence
{
    public class BookContext : DbContext
    {
        public BookContext() { }
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public virtual DbSet<BookModel> Book { get; set; }
    }
}
