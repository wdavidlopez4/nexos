﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexos.Infrastructure;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Nexos.Infrastructure.Migrations
{
    [DbContext(typeof(NexosDbContext))]
    [Migration("20220707054928_NexosMugration1")]
    partial class NexosMugration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Nexos")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nexos.Domain.Authors.Author", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("id");

                    b.Property<string>("CityOfBirth")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ciudad_cumpleanos");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("fecha_cumpleanos");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("correo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Autor", "Nexos");
                });

            modelBuilder.Entity("Nexos.Domain.Books.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("id");

                    b.Property<DateTime>("Anno")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("anno");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nombre_autor");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("genero");

                    b.Property<int>("PageNumber")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("numero_pagina");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("Libro", "Nexos");
                });

            modelBuilder.Entity("Nexos.Domain.Books.Book", b =>
                {
                    b.OwnsOne("Nexos.Domain.Authors.AuthorId", "AuthorId", b1 =>
                        {
                            b1.Property<string>("BookId")
                                .HasColumnType("NVARCHAR2(450)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("autorId");

                            b1.HasKey("BookId");

                            b1.ToTable("Libro", "Nexos");

                            b1.WithOwner()
                                .HasForeignKey("BookId");
                        });

                    b.Navigation("AuthorId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
