using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Books.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }

        public string Title { get; set; }

        public DateTime Anno { get; set; }

        public string AuthorName { get; set; }

        public string Genero { get; set; }

        public int PageNumber { get; set; }
    }
}
