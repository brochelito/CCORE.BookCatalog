using MediatR;

namespace CCORE.BookCatalog.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    { 
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public override string ToString()
        {
            return $"Book Title: {Title}; On: {PublishDateUtc.ToShortDateString()}; Description: {Description}";
        }
    }
}
