using LibraryProj.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProj.Context
{
    public class libraryDbContext : DbContext
    {
        public libraryDbContext(DbContextOptions<libraryDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nombre = "Ficción" },
                new Genero { Id = 2, Nombre = "No Ficción" },
                new Genero { Id = 3, Nombre = "Fantasía" }
            );

            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nombre = "Autor 1", FechaNacimiento = new DateTime(1970, 1, 1) },
                new Autor { Id = 2, Nombre = "Autor 2", FechaNacimiento = new DateTime(1980, 2, 2) }
            );

            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1001, Isbn = 1111111, Titulo = "Libro 1", AutorId = 1, GeneroId = 1, FechaPublicacion = new DateTime(2000, 1, 1) },
                new Libro { Id = 1002, Isbn = 2222222, Titulo = "Libro 2", AutorId = 1, GeneroId = 2, FechaPublicacion = new DateTime(2001, 2, 2) },
                new Libro { Id = 1003, Isbn = 3333333, Titulo = "Libro 3", AutorId = 1, GeneroId = 3, FechaPublicacion = new DateTime(2002, 3, 3) },
                new Libro { Id = 1004, Isbn = 4444444, Titulo = "Libro 4", AutorId = 2, GeneroId = 1, FechaPublicacion = new DateTime(2003, 4, 4) },
                new Libro { Id = 1005, Isbn = 5555555, Titulo = "Libro 5", AutorId = 2, GeneroId = 2, FechaPublicacion = new DateTime(2004, 5, 5) },
                new Libro { Id = 1006, Isbn = 6666666, Titulo = "Libro 6", AutorId = 2, GeneroId = 3, FechaPublicacion = new DateTime(2005, 6, 6) }
            );
        }
    }
}
