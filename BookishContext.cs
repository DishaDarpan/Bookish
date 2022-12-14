using bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace bookish
{
    public class BookishContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish; Password=bookish;");
        }

    }
}
