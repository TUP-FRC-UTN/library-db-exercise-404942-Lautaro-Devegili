using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryProj.Migrations
{
    /// <inheritdoc />
    public partial class primerTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "FechaNacimiento", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autor 1" },
                    { 2, new DateTime(1980, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autor 2" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ficción" },
                    { 2, "No Ficción" },
                    { 3, "Fantasía" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "AutorId", "FechaPublicacion", "GeneroId", "Isbn", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1111111, "Libro 1" },
                    { 2, 1, new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2222222, "Libro 2" },
                    { 3, 1, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3333333, "Libro 3" },
                    { 4, 2, new DateTime(2003, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4444444, "Libro 4" },
                    { 5, 2, new DateTime(2004, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5555555, "Libro 5" },
                    { 6, 2, new DateTime(2005, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6666666, "Libro 6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorId",
                table: "Libros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_GeneroId",
                table: "Libros",
                column: "GeneroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
