using Microsoft.EntityFrameworkCore;
using Nexos.Domain.Authors;
using Nexos.Domain.Books;
using Nexos.Infrastructure.Autors;
using Nexos.Infrastructure.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure
{
    public class NexosDbContext : DbContext
    {
        public DbSet<Author>? Authors { get; set; }

        public DbSet<Book>? Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=nexos_db_prueba; Password=123456; Data Source=localhost:1521/XE;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuracion de entidades
            modelBuilder.ApplyConfiguration(new AuthorEFConfiguration());
            modelBuilder.ApplyConfiguration(new BooksEFConfiguration());
        }
    }
}
