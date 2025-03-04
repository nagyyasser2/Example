using Example.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.EF
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}