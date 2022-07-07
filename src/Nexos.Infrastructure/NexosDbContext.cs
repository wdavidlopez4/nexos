using Microsoft.EntityFrameworkCore;
using Nexos.Domain.Authors;
using Nexos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure
{
    public class NexosDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public NexosDbContext(DbContextOptions<NexosDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de esquema de este modulo
            modelBuilder.HasDefaultSchema("Nexos");
        }
    }
}
