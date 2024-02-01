using MediatR;

namespace CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList
{
    public class GetBooksListQuery : IRequest<List<BookListVm>>
    {
        public GetBooksListQueryParameter QueryParameter { get; set; } = new GetBooksListQueryParameter();
    }
}
