using MediatR;
using Nexos.Domain;
using Nexos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Books.SearchBooksByKeyword
{
    public class SearchBooksByKeywordHandler : IRequestHandler<SearchBooksByKeywordQuery, List<SearchBooksByKeywordDTO>>
    {
        private readonly IBooksRepository repository;

        private readonly IMapObject mapObject;

        public SearchBooksByKeywordHandler(IBooksRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<SearchBooksByKeywordDTO>> Handle(SearchBooksByKeywordQuery request, 
            CancellationToken cancellationToken)
        {
            List<Book> books = new();

            //vertificar palabra clave y obtener autores
            if (!string.IsNullOrEmpty(request.AuthorName))
                books = await repository.GetAll(x => x.AuthorName == request.AuthorName);
            else if(!string.IsNullOrEmpty(request.Title))
                books = await repository.GetAll(x => x.Title == request.Title);
            else if(request.Anno is not null)
                books = await repository.GetAll(x => x.Anno == request.Anno);

            //verificar total elementos
            if (books.Count == 0)
                throw new Exception("ningun registro encontrado");

            //mapear y retornar
            return this.mapObject.Map<List<Book>, List<SearchBooksByKeywordDTO>>(books);
        }
    }
}
