using AutoMapper;
using CCORE.BookCatalog.Application.Features.Books.Commands.CreateBook;
using CCORE.BookCatalog.Application.Features.Books.Commands.UpdateBook;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBookDetail;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using CCORE.BookCatalog.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCORE.BookCatalog.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookListVm>().ReverseMap();
            CreateMap<Book, BookDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();                 
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();               
        }
    }
}
