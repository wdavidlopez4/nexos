using Nexos.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure.Autors
{
    public class AuthorRepositoryOracle : IAuthorRepository
    {
        public Task Commit()
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Author, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Author> Get(Expression<Func<Author, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Save(Author user)
        {
            throw new NotImplementedException();
        }
    }
}
