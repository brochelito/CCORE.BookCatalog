using CCORE.BookCatalog.Domain.Entities;
using CCORE.BookCatalog.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCORE.BookCatalog.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(BookCatalogDbContext context)
        {
            var scienceFictionGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var fantasyGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var mysteryGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");


            context.Books.Add(new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = scienceFictionGuid,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Description = "A comedic science fiction series",
                PublishDateUtc = new DateTime(1979, 10, 12)
            });
            context.Books.Add(new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = fantasyGuid,
                Title = "The Lord of the Rings",
                Description = "Epic high-fantasy novel",
                PublishDateUtc = new DateTime(1954, 7, 29)
            });
            context.Books.Add(new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = mysteryGuid,
                Title = "The Da Vinci Code",
                Description = "Mystery thriller novel",
                PublishDateUtc = new DateTime(2003, 3, 18)
            });          

            context.SaveChanges();
        }
    }
}
