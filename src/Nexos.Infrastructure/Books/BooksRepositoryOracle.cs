using Nexos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure.Books
{
    public class BooksRepositoryOracle : IBooksRepository
    {
        public Task Commit()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAll(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Save(Book user)
        {
            throw new NotImplementedException();
        }
    }
}
