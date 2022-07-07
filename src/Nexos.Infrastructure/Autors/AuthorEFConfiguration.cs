using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexos.Domain.Authors;
using Nexos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Infrastructure.Autors
{
    public class AuthorEFConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //configurar nombre de tabla
            builder.ToTable("Autor");

            //configurar primary key
            builder.HasKey(x => x.Id);

            //configuracion propiedades

            builder.Property(x => x.Id)
                .HasConversion(y => y.Value, y => new AuthorId(y))
                .HasColumnName("id");

            builder.Property(x => x.Email)
                .HasConversion(y => y.Value, y => new AuthorEmail(y))
                .HasColumnName("correo");

            builder.Property(x => x.Name)
                .HasColumnName(nameof(Author.Name))
                .HasColumnName("nombre");

            builder.Property(x => x.DateOfBirth)
                .HasColumnName(nameof(Author.DateOfBirth))
                .HasColumnName("fecha_cumpleanos");

            builder.Property(x => x.CityOfBirth)
                .HasColumnName(nameof(Author.CityOfBirth))
                .HasColumnName("ciudad_cumpleanos");
        }
    }
}
