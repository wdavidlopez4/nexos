using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexos.Domain.Authors;
using Nexos.Domain.Books;
using Nexos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure.Books
{
    public class BooksEFConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //configurar nombre de tabla
            builder.ToTable("Libro");

            //configurar VO
            builder.Property(x => x.Id)
               .HasConversion(y => y.Value, y => new BookId(y))
               .HasColumnName("id");

            builder.Property(x => x.AuthorId)
               .HasConversion(y => y.Value, y => new AuthorId(y))
               .HasColumnName("AuthorId");


            //configurar propiedades
            builder.Property(x => x.AuthorName)
                .HasColumnName(nameof(Book.AuthorName))
                .HasColumnName("nombre_autor");

            builder.Property(x => x.Title)
                .HasColumnName(nameof(Book.Title))
                .HasColumnName("titulo");

            builder.Property(x => x.Anno)
                .HasColumnName(nameof(Book.Anno))
                .HasColumnName("anno");

            builder.Property(x => x.Genero)
                .HasColumnName(nameof(Book.Genero))
                .HasColumnName("genero");

            builder.Property(x => x.PageNumber)
                .HasColumnName(nameof(Book.PageNumber))
                .HasColumnName("numero_pagina");

            //configurar primary key
            builder.HasKey(x => x.Id);

            //clave foranea
            builder.HasOne<Author>()
                .WithMany()
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
