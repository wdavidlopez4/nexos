using Nexos.Domain.Authors;
using Nexos.Domain.Books.Events;
using pmilet.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Authors.verifyAuthorExistence
{
    public class VerifyAuthorExistenceDomainEventHandler : HandleDomainEventsBase<BookCreatedDomaintEvent>
    {
        private readonly IAuthorRepository repository;

        public VerifyAuthorExistenceDomainEventHandler(IDomainEventDispatcher dispatcher, IAuthorRepository repository)
            : base(dispatcher)
        {
            this.repository = repository;
        }

        public override async void HandleEvent(BookCreatedDomaintEvent domainEvent)
        {
            Author author;

            //verificamos si ya esta registrado
            if (repository.Exists(x => x.Id.Value == domainEvent.Id) == false)
                throw new Exception("El autor no esta registrado");

            //verificamos si el nombre registrado es correcto con el que envian, asi se mantiene la integridad de datos
            author = await repository.Get(x => x.Id.Value == domainEvent.Id);
            if (!author.Name.Equals(domainEvent.AuthorName))
                throw new Exception("El nombre del autor no corresponde.");
        }
    }
}
