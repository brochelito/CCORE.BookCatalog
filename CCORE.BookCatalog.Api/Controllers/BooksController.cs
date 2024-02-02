using CCORE.BookCatalog.Api.Controllers;
using CCORE.BookCatalog.Application.Common;
using CCORE.BookCatalog.Application.Features.Books.Commands.CreateBook;
using CCORE.BookCatalog.Application.Features.Books.Commands.DeleteBook;
using CCORE.BookCatalog.Application.Features.Books.Commands.UpdateBook;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBookDetail;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCORE.BookCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<List<BookListVm>>> GetAllBooks([FromQuery] GetBooksListQueryParameter queryParameter)
        {
            var result = await _mediator.Send(new GetBooksListQuery { QueryParameter = queryParameter });
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetBookById")]
        [Authorize]
        public async Task<ActionResult<BookDetailVm>> GetBookById(Guid id)
        {
            var getBookDetailQuery = new GetBookDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getBookDetailQuery));
        }

        [HttpPost(Name = "AddBook")]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookCommand createBookCommand)
        {
            var id = await _mediator.Send(createBookCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
        {
            await _mediator.Send(updateBookCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookCommand = new DeleteBookCommand() { Id = id };
            await _mediator.Send(deleteBookCommand);
            return NoContent();
        }      
    }
}
