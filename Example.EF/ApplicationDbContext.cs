using Example.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Example.EF.Configurations;

namespace Example.EF
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserPermissionEntityTypeConfiguration().Configure(modelBuilder.Entity<UserPermission>());
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
    }
}