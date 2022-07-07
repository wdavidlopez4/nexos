using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Books.SearchBooksByKeyword
{
    public class SearchBooksByKeywordQuery : IRequest<List<SearchBooksByKeywordDTO>>
    {
        public string AuthorName { get; set; }

        public string Title { get; set; }

        public DateTime? Anno { get; set; }
    }
}
