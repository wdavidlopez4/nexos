using MediatR;
using Nexos.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Authors.CreateAuthor
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorRepository repository;

        public CreateAuthorHandler(IAuthorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author;

            author = Author.Build(
                id: new AuthorId(request.Id),
                name: request.Name,
                dateOfBirth: request.DateOfBirth,
                email: new AuthorEmail(request.Id),
                cityOfBirth: request.CityOfBirth);

            await repository.Save(author);
            await repository.Commit();

            return 0;
        }
    }
}
