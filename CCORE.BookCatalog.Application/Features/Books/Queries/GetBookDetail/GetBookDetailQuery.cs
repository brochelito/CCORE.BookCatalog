using MediatR;

namespace CCORE.BookCatalog.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery : IRequest<BookDetailVm>
    {
        public Guid Id { get; set; }
    }    
}
