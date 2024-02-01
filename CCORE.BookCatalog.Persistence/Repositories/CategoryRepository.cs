using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CCORE.BookCatalog.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookCatalogDbContext dbContext) : base(dbContext)
        {
        }      
    }
}
