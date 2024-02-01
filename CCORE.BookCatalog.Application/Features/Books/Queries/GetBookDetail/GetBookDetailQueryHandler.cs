using AutoMapper;
using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Domain.Entities;
using MediatR;

namespace CCORE.BookCatalog.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDetailVm>
    {
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetBookDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Book> bookRepository,
            IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<BookDetailVm> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            var bookDetailDto = _mapper.Map<BookDetailVm>(book);

            var category = await _categoryRepository.GetByIdAsync(book.CategoryId);

            bookDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return bookDetailDto;
        }
    }
}
