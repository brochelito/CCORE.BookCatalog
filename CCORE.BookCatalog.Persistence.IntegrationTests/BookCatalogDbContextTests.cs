using CCORE.BookCatalog.Application.Contracts;
using CCORE.BookCatalog.Domain.Entities;
using CCORE.BookCatalog.Persistence.IntegrationTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCORE.BookCatalog.Persistence.IntegrationTests
{
    public class BookCatalogDbContextTests
    {
        private readonly BookCatalogDbContext _bookCatalogDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public BookCatalogDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<BookCatalogDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _bookCatalogDbContext = new BookCatalogDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var scienceFictionGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var book = new Book
            {
                Id = Guid.NewGuid(),
                CategoryId = scienceFictionGuid,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Description = "A comedic science fiction series",
                PublishDateUtc = new DateTime(1979, 10, 12)
            };

            _bookCatalogDbContext.Books.Add(book);
            await _bookCatalogDbContext.SaveChangesAsync();

            book.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
