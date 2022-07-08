using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexos.Application.Books.CreateBook;
using Nexos.Application.Books.SearchBooksByKeyword;

namespace Nexos.API.Books
{
    [TypeFilter(typeof(ExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Put(CreateBookRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var command = new CreateBookCommand
            {
                Anno = request.Anno,
                AuthorId = request.AuthorId,
                AuthorName = request.AuthorName,
                Genero = request.Genero,
                PageNumber = request.PageNumber,
                Title = request.Title
            };

            var dto = await mediator.Send(command);
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(SearchBooksByKeywordRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var query = new SearchBooksByKeywordQuery
            {
                Anno = request.Anno,
                AuthorName = request.AuthorName,
                Title = request.Title
            };

            var dto = await mediator.Send(query);
            return Ok(dto);
        }
    }
}
