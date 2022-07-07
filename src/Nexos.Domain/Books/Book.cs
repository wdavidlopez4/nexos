using Nexos.Domain.Authors;
using Nexos.Domain.Books.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Domain.Books
{
    public class Book : Aggregate
    {
        public BookId Id { get; private set; }

        public AuthorId AuthorId { get; private set; }

        public string AuthorName { get; private set; }

        public string Title { get; private set; }

        public DateTime Anno { get; private set; }

        public string Genero { get; private set; }

        public int PageNumber { get; private set; }


        /// <summary>
        /// for ef
        /// </summary>
        private Book() : base()
        {

        }

        private Book(BookId id, string authorName, AuthorId authorId, string title, DateTime anno, string genero, int pageNumber)
            : base()
        {
            //validar
            if (id is null)
                throw new ArgumentNullException("id");
            else if (authorId is null)
                throw new ArgumentNullException("el libro debe tener un autor asociado.");
            else if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("titulo");
            else if (string.IsNullOrEmpty(genero))
                throw new ArgumentNullException("genero");
            else if (string.IsNullOrEmpty(authorName))
                throw new ArgumentNullException("nombre autor");

            //asignar
            Id = id;
            AuthorId = authorId;
            Title = title;
            Anno = anno;
            Genero = genero;
            PageNumber = pageNumber;
            AuthorName = authorName;

            //publicar evento
            this.dispatcher.Publish<BookCreatedDomaintEvent>(
                new BookCreatedDomaintEvent(id, authorName, authorId, title, anno, genero, pageNumber));

        }

        public static Book Build(BookId id, string authorName, AuthorId authorId, string title, DateTime anno, string genero, int pageNumber)
        {
            return new Book(id, authorName, authorId, title, anno, genero, pageNumber);
        }

    }
}
