using AutoMapper;
using CCORE.BookCatalog.Application.Contracts.Persistence;
using CCORE.BookCatalog.Application.Exceptions;
using CCORE.BookCatalog.Application.Features.Books.Commands.UpdateBook;
using CCORE.BookCatalog.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCORE.BookCatalog.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IMapper mapper, IAsyncRepository<Book> bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {

            var bookToUpdate = await _bookRepository.GetByIdAsync(request.Id);

            if (bookToUpdate == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            var validator = new UpdateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, bookToUpdate, typeof(UpdateBookCommand), typeof(Book));

            await _bookRepository.UpdateAsync(bookToUpdate);
        }
    }
}
