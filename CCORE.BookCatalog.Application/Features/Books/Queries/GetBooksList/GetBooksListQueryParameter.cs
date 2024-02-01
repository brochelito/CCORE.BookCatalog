using CCORE.BookCatalog.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList
{
    public class GetBooksListQueryParameter : QueryParameter
    {
        public string? Title { get; set; }
        public string? Description { get; set; } 
        public string? SearchTerm { get; set; } 
    }
}
