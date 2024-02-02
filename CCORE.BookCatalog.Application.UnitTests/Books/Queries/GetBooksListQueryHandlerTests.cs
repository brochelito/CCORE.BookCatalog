using AutoMapper;
using CCORE.BookCatalog.Application.Common;
using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Application.Features.Books.Commands.CreateBook;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using CCORE.BookCatalog.Application.UnitTests.Books.Queries;
using CCORE.BookCatalog.Application.UnitTests.Mocks;
using CCORE.BookCatalog.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCORE.BookCatalog.Application.UnitTests.Books.Queries
{
    public class GetBooksListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBookRepository> _mockBookRepository;
       
        public GetBooksListQueryHandlerTests()
        {
            _mockBookRepository = RepositoryMocks.GetBookRepository();
          
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();         
        }

        [Fact]
        public async Task GetBooksListTest()
        {
            var handler = new GetBooksListQueryHandler(_mapper, _mockBookRepository.Object);
         
            var result = await handler.Handle(new GetBooksListQuery { QueryParameter = new GetBooksListQueryParameter() }, CancellationToken.None);

            result.ShouldBeOfType<List<BookListVm>>();

            result.Count.ShouldBe(3);
        }
    }
}
