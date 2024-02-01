using CCORE.BookCatalog.Domain.Entities;

namespace CCORE.BookCatalog.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
