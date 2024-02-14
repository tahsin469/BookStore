using Microsoft.EntityFrameworkCore;

namespace YtBookStore1.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        //DB Table Name
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
