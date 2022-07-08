using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexos.Infrastructure.Migrations
{
    public partial class nexosMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    fecha_cumpleanos = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    correo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ciudad_cumpleanos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    AuthorId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    nombre_autor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    anno = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    numero_pagina = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.id);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Autor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AuthorId",
                table: "Libro",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
