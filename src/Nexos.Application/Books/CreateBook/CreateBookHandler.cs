using MediatR;
using Nexos.Domain.Authors;
using Nexos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Books.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBooksRepository repository;

        public CreateBookHandler(IBooksRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book;

            book = Book.Build(
                id: new BookId(request.Id),
                authorName: request.AuthorName,
                authorId: new AuthorId(request.AuthorId),
                title: request.Title,
                anno: request.Anno,
                genero: request.Genero,
                pageNumber: request.PageNumber);

            await repository.Save(book);
            await repository.Commit();

            return 0;
        }
    }
}
