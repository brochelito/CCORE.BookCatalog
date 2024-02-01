using CCORE.BookCatalog.Domain.Common;

namespace CCORE.BookCatalog.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Book>? Books { get; set; }
    }
}
