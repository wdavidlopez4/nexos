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
        private readonly NexosDbContext context;

        public AuthorRepositoryOracle(NexosDbContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public bool Exists(Expression<Func<Author, bool>> expression)
        {
            return context.Authors.AsQueryable().Any(expression);
        }

        public async Task<Author> Get(Expression<Func<Author, bool>> expression)
        {
            return await context.Authors.FindAsync(expression);
        }

        public async Task Save(Author user)
        {
            await context.Authors.AddAsync(user);
        }
    }
}
