using AutoMapper;
using CCORE.BookCatalog.Application.Common;
using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Application.Features.Books.Commands.CreateBook;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using CCORE.BookCatalog.Application.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace CCORE.BookCatalog.Application.UnitTests.Books.Commands
{
    public class CreateBookTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<ILogger<CreateBookCommandHandler>> _mockLogger;
        public CreateBookTests()
        {
            _mockBookRepository = RepositoryMocks.GetBookRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _mockLogger = new Mock<ILogger<CreateBookCommandHandler>>();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToBooksRepo()
        {
            var handler = new CreateBookCommandHandler(_mapper, _mockBookRepository.Object, _mockLogger.Object);
            var thrillerGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            await handler.Handle(new CreateBookCommand()
            {             
                CategoryId = thrillerGuid,
                Title = "The Girl with the Dragon Tattoo",
                Description = "Crime thriller novel",
                PublishDateUtc = new DateTime(2005, 8, 23)
            }, CancellationToken.None);

            var allBooks = await _mockBookRepository.Object.ListAllAsync(It.IsAny<GetBooksListQuery>());
            allBooks.Count.ShouldBe(4);
        }
    }
}
