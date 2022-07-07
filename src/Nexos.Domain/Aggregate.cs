using pmilet.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Domain
{
    public abstract class Aggregate
    {
        public IDomainEventDispatcher dispatcher { get; }

        public Aggregate()
        {
            this.dispatcher = new DomainEventDispatcher();
        }
    }
}
