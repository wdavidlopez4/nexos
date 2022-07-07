using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Domain.Books
{
    public interface IBooksRepository
    {
        public Task Save(Book user);

        public Task Commit();

        public bool Exists(Expression<Func<Book, bool>> expression);

        public int Count();

        public Task<List<Book>> GetAll(Expression<Func<Book, bool>> expression);
    }
}
