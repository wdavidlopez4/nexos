using Microsoft.EntityFrameworkCore;
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
        private readonly NexosDbContext context;

        public BooksRepositoryOracle(NexosDbContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public int Count()
        {
            return context.Books.Count();
        }

        public bool Exists(Expression<Func<Book, bool>> expression)
        {
            return context.Books.AsQueryable().Any(expression);
        }

        public async Task<List<Book>> GetAll(Expression<Func<Book, bool>> expression)
        {
            return await context.Books
                .Where(expression)
                .ToListAsync();
        }

        public async Task Save(Book user)
        {
            await context.Books.AddAsync(user);
        }
    }
}
