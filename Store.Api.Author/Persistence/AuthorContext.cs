using Microsoft.EntityFrameworkCore;
using Store.Api.Author.Model;

namespace Store.Api.Author.Persistence
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }

        public virtual DbSet<BookAuthor> Author { get; set; }
        public virtual DbSet<Degree> Degree { get; set; }
    }
}
