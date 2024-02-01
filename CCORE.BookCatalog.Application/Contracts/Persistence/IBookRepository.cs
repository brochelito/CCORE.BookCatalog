using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using CCORE.BookCatalog.Domain.Entities;

namespace CCORE.BookCatalog.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task<IReadOnlyList<Book>> ListAllAsync(GetBooksListQuery request);
    }
}
