using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nexos.Application.Authors.CreateAuthor;
using Nexos.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nexos.UnitTest.Authors
{
    [TestClass]
    public class CreateAutor
    {
        private readonly Mock<IAuthorRepository> repository;

        public CreateAutor()
        {
            repository = new Mock<IAuthorRepository>();
        }

        [TestMethod]
        public async Task CreateAutorHandler()
        {
            string id = "9735aa73-673a-4608-8992-6dfbb146242e";
            string name = "david lopez";
            string email = "wdavidlopez4@gmail.com";
            string city = "miraflores";
            DateTime date = DateTime.Now;

            var command = new CreateAuthorCommand
            {
                Id = id,
                Name = name,
                Email = email,
                CityOfBirth = city,
                DateOfBirth = date,
            };

            var autor = Author.Build(
                id: new AuthorId(id), 
                name: name, 
                dateOfBirth: date, 
                email: new AuthorEmail(email), 
                cityOfBirth: city);

            repository.Setup(x => x.Save(autor))
               .Returns(Task.CompletedTask)
               .Verifiable();

            repository.Setup(x => x.Commit())
               .Returns(Task.CompletedTask)
               .Verifiable();

            var handler = new CreateAuthorHandler(repository.Object);
            int result = await handler.Handle(request: command, cancellationToken: new CancellationToken());

            Assert.AreEqual(result, 0);
        }
    }
}
