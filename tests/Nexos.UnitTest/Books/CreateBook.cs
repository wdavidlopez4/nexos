using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nexos.Application.Books.CreateBook;
using Nexos.Domain.Authors;
using Nexos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nexos.UnitTest.Books
{
    [TestClass]
    public class CreateBook
    {
        private readonly Mock<IBooksRepository> repository;

        public CreateBook()
        {
            repository = new Mock<IBooksRepository>();
        }

        [TestMethod]
        public async Task CreateBookHandler()
        {
            string id = "9735aa73-673a-4608-8992-6dfbb146242e";
            string autorId = "9735aa73-673a-4608-8992-6dfbb146242a";
            DateTime anno = DateTime.Now;
            string genero = "masculino";
            int pageNumber = 1;
            string title = "Cleam architecture";
            string name = "william lopez";

            var command = new CreateBookCommand
            {
                AuthorName = name,
                Anno = anno,
                AuthorId = autorId,
                Genero = genero,
                PageNumber = pageNumber,
                Title = title
            };

            var book = Book.Build(
                id : new BookId(id),
                authorName : name,
                anno : anno,
                authorId : new AuthorId(autorId),
                genero : genero,
                pageNumber : pageNumber,
                title : title);

            repository.Setup(x => x.Save(book))
               .Returns(Task.CompletedTask)
               .Verifiable();

            repository.Setup(x => x.Commit())
               .Returns(Task.CompletedTask)
               .Verifiable();

            var handler = new CreateBookHandler(repository.Object);
            int result = await handler.Handle(request: command, cancellationToken: new CancellationToken());

            Assert.AreEqual(result, 0);
        }
    }
}
