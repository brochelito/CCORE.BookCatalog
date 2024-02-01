using CCORE.BookCatalog.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CCORE.BookCatalog.Identity
{
    public class BookCatalogIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookCatalogIdentityDbContext()
        {

        }

        public BookCatalogIdentityDbContext(DbContextOptions<BookCatalogIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
               .LogTo(Console.WriteLine)
               .EnableSensitiveDataLogging();

    }
}
