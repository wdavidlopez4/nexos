using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexos.Infrastructure.Migrations
{
    public partial class NexosMugration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Nexos");

            migrationBuilder.CreateTable(
                name: "Autor",
                schema: "Nexos",
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
                schema: "Nexos",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    autorId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nombre_autor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    anno = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    numero_pagina = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor",
                schema: "Nexos");

            migrationBuilder.DropTable(
                name: "Libro",
                schema: "Nexos");
        }
    }
}
