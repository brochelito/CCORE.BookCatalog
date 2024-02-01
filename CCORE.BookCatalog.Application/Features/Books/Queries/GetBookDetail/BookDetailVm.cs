namespace CCORE.BookCatalog.Application.Features.Books.Queries.GetBookDetail
{
    public class BookDetailVm
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public CategoryDto Category { get; set; }
    }
}
