using Nexos.Domain.Authors;
using Nexos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Books.SearchBooksByKeyword
{
    public class SearchBooksByKeywordDTO
    {
        public BookId Id { get; set; }

        public AuthorId AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        public DateTime Anno { get; set; }

        public string Genero { get; set; }

        public int PageNumber { get; set; }
    }
}
