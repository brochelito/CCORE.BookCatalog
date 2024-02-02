using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using CCORE.BookCatalog.Domain.Entities;
using Moq;

namespace CCORE.BookCatalog.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IBookRepository> GetBookRepository()
        {
            var scienceFictionGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var fantasyGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var mysteryGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
         
            var books = new List<Book>
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                    CategoryId = scienceFictionGuid,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description = "A comedic science fiction series",
                    PublishDateUtc = new DateTime(1979, 10, 12)
                },
                new Book
                {
                     Id = Guid.NewGuid(),
                     CategoryId = fantasyGuid,
                     Title = "The Lord of the Rings",
                     Description = "Epic high-fantasy novel",
                     PublishDateUtc = new DateTime(1954, 7, 29)
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    CategoryId = mysteryGuid,
                    Title = "The Da Vinci Code",
                    Description = "Mystery thriller novel",
                    PublishDateUtc = new DateTime(2003, 3, 18)
                }               
            };

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.ListAllAsync(It.IsAny<GetBooksListQuery>()))
                          .ReturnsAsync(books);

            mockBookRepository.Setup(repo => repo.AddAsync(It.IsAny<Book>())).ReturnsAsync(
                (Book book) =>
                {
                    books.Add(book);
                    return book;
                });

            return mockBookRepository;
        }
    }
}
