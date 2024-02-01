using CCORE.BookCatalog.Domain.Common;
using CCORE.BookCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCORE.BookCatalog.Application.Contracts;

namespace CCORE.BookCatalog.Persistence
{
    public class BookCatalogDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options)
           : base(options)
        {
        }

        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookCatalogDbContext).Assembly);
         
            var scienceFictionGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var fantasyGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var mysteryGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var thrillerGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = scienceFictionGuid,
                Name = "Science Fiction"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = fantasyGuid,
                Name = "Fantasy"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = mysteryGuid,
                Name = "Mystery"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = thrillerGuid,
                Name = "Thriller"
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = scienceFictionGuid,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Description = "A comedic science fiction series",
                PublishDateUtc = new DateTime(1979, 10, 12)             
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = fantasyGuid,
                Title = "The Lord of the Rings",
                Description = "Epic high-fantasy novel",
                PublishDateUtc = new DateTime(1954, 7, 29)
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = mysteryGuid,
                Title = "The Da Vinci Code",
                Description = "Mystery thriller novel",
                PublishDateUtc = new DateTime(2003, 3, 18)
            });
          
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = thrillerGuid,
                Title = "The Girl with the Dragon Tattoo",
                Description = "Crime thriller novel",
                PublishDateUtc = new DateTime(2005, 8, 23)
            });      
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
