using Nexos.Domain.Books;
using Nexos.Domain.Books.Events;
using pmilet.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Application.Books.VerifyBookLimitByAuthor
{
    public class AddAdditionalInformation : HandleDomainEventsBase<BookCreatedDomaintEvent>
    {
        private const int LIMIT = 3;

        private readonly IBooksRepository repository;

        public AddAdditionalInformation(IDomainEventDispatcher dispatcher, IBooksRepository repository)
            : base(dispatcher)
        {
            this.repository = repository;
        }

        public override void HandleEvent(BookCreatedDomaintEvent domainEvent)
        {
            if (repository.Count() > LIMIT)
                throw new Exception("No es posible registrar el libro, se alcanzo el maximo permitido");
        }
    }
}
