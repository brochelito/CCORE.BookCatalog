using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using CCORE.BookCatalog.Domain.Entities;
using CCORE.BookCatalog.Application.Common;
using Microsoft.EntityFrameworkCore;


namespace CCORE.BookCatalog.Persistence.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookCatalogDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Book>> ListAllAsync(GetBooksListQuery request)
        {
            var searchTerm = request.QueryParameter.SearchTerm;
            var title = request.QueryParameter.Title;
            var description = request.QueryParameter.Description;
            var size = request.QueryParameter.Size;
            var page = request.QueryParameter.Page;
            var sortBy = request.QueryParameter.SortBy;
            var sortOrder = request.QueryParameter.SortOrder;

            IQueryable<Book> allBooks = _dbContext.Books;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                allBooks = allBooks.Where(
                             e => e.Title.ToLower().Contains(searchTerm.ToLower())
                                 || e.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(title))
            {
                allBooks = allBooks.Where(e => e.Title.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrEmpty(description))
            {
                allBooks = allBooks.Where(e => e.Description.ToLower().Contains(description.ToLower()));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (typeof(Book).GetProperty(sortBy) != null)
                {
                    allBooks = allBooks.OrderByCustom(sortBy, sortOrder);
                }
            }

            allBooks = allBooks.Skip((page - 1) * size).Take(size);

            return await allBooks.ToListAsync();

        }
    }
}
