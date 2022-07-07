using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Domain.Authors
{
    public interface IAuthorRepository
    {
        public Task Save(Author author);

        public Task Commit();

        public bool Exists(Expression<Func<Author, bool>> expression);

        public Task<Author> Get(Expression<Func<Author, bool>> expression);
    }
}
