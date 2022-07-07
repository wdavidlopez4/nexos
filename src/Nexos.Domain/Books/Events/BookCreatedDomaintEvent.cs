using Nexos.Domain.Authors;
using pmilet.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Domain.Books.Events
{
    public class BookCreatedDomaintEvent : DomainEvent
    {
        public string Id { get; private set; }

        public string AuthorId { get; private set; }

        public string AuthorName { get; private set; }

        public string Title { get; private set; }

        public DateTime Anno { get; private set; }

        public string Genero { get; private set; }

        public int PageNumber { get; private set; }

        public BookCreatedDomaintEvent(BookId id, string authorName, AuthorId authorId, string title, 
            DateTime anno, string genero, int pageNumber) : base("BookCreatedDomaintEventt", "1.0")
        {
            Id = id.Value;
            AuthorId = authorId.Value;
            Title = title;
            Anno = anno;
            Genero = genero;
            PageNumber = pageNumber;
            AuthorName = authorName;
        }
    }
}
