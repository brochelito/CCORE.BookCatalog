namespace CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList
{
    public class BookListVm 
    {
        public Guid Id { get; set; }     
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime PublishDateUtc { get; set; }   
    }
}
