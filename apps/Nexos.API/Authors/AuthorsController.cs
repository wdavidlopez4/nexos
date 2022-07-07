using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexos.Application.Authors.CreateAuthor;

namespace Nexos.API.Authors
{
    [TypeFilter(typeof(ExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Put(CreateAuthorsRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception("modelo invalido");

            var command = new CreateAuthorCommand
            {
                Id = request.Id,
                CityOfBirth = request.CityOfBirth,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Name = request.Name
            };

            var dto = await mediator.Send(command);
            return Ok(dto);
        }

    }
}
