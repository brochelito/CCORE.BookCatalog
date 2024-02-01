using CCORE.BookCatalog.Domain.Common;

namespace CCORE.BookCatalog.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PublishDateUtc { get; set; }
        public Category Category { get; set; } = default!;
    }
}
