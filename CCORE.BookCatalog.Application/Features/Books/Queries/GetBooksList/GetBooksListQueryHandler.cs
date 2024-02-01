using AutoMapper;
using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Domain.Entities;
using MediatR;

namespace CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList
{
    public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<BookListVm>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksListQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<List<BookListVm>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            var allBooks = (await _bookRepository.ListAllAsync(request)).OrderBy(x => x.PublishDateUtc);
            return _mapper.Map<List<BookListVm>>(allBooks);
        }
    }
}
