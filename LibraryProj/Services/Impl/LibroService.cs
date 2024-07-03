using LibraryProj.Context;
using LibraryProj.DTOs;
using LibraryProj.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProj.Services.Impl
{
    public class LibroService : ILibroService
    {

        private readonly libraryDbContext _context;

        public LibroService(libraryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLibro(CreateLibroDTO libro)
        {
            try
            {
                Libro libroNuevo = new Libro();
                libroNuevo.Titulo = libro.Titulo;
                libroNuevo.Isbn = libro.ISBN;
                libroNuevo.FechaPublicacion = libro.FechaPublicacion;
                libroNuevo.AutorId = libro.IdAutor;
                libroNuevo.GeneroId = libro.IdGenero;
                libroNuevo.Autor = await _context.Autores.FindAsync(libro.IdAutor);
                libroNuevo.Genero = await _context.Generos.FindAsync(libro.IdGenero);
                var seCreo = await _context.Libros.AddAsync(libroNuevo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el libro: {ex.Message}");
                return false;
            }
            
        }

        public Task<List<GetLibroDTO>> GetAllLibros()
        {
            var libros = _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .Select(l => new GetLibroDTO
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    ISBN = l.Isbn,
                    FechaPublicacion = l.FechaPublicacion,
                    Autor = l.Autor.Nombre,
                    Genero = l.Genero.Nombre
                })
                .ToListAsync();
            return libros;
        }

        public async Task<bool> UpdateLibro(UpdateLibroDTO libro)
        {
            try
            {
                var libroAModificar = await _context.Libros.FindAsync(libro.Id);
                if (libroAModificar == null)
                {
                    return false;
                }

                var nuevoAutor = await _context.Autores.FindAsync(libro.IdAutor);
                if (nuevoAutor == null)
                {
                    return false; 
                }

                var nuevoGenero = await _context.Generos.FindAsync(libro.IdGenero);
                if (nuevoGenero == null)
                {
                    return false;
                }

                libroAModificar.Titulo = libro.Titulo;
                libroAModificar.Isbn = libro.ISBN;
                libroAModificar.FechaPublicacion = libro.FechaPublicacion;
                libroAModificar.AutorId = libro.IdAutor;
                libroAModificar.Autor = nuevoAutor;
                libroAModificar.GeneroId = libro.IdGenero;
                libroAModificar.Genero = nuevoGenero;

                _context.Libros.Update(libroAModificar);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el libro: {ex.Message}");
                return false;
            }
            
        }


        public Task<bool> DeleteLibro(int idlibro)
        {
            try
            {
                var libroAEliminar = _context.Libros.Find(idlibro);
                if (libroAEliminar == null)
                {
                    return Task.FromResult(false);
                }
                _context.Libros.Remove(libroAEliminar);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el libro: {ex.Message}");
                return Task.FromResult(false);
            }
        }

        public Task<List<GetAutorDTO>> GetAllAutores()
        {
            var autores = _context.Autores
                .Select(a => new GetAutorDTO
                {
                    Id = a.Id,
                    Nombre = a.Nombre
                })
                .ToListAsync();
            return autores;
        }

        public Task<List<GetGeneroDTO>> GetAllGeneros()
        {
            var generos = _context.Generos
                .Select(g => new GetGeneroDTO
                {
                    Id = g.Id,
                    Nombre = g.Nombre
                })
                .ToListAsync();
            return generos;
        }

        public Task<UpdateLibroDTO> GetLibroById(int id)
        {
            var libro = _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .Where(l => l.Id == id)
                .Select(l => new UpdateLibroDTO
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    ISBN = l.Isbn,
                    FechaPublicacion = l.FechaPublicacion,
                    IdAutor = l.AutorId,
                    IdGenero = l.GeneroId,
                    NombreAutor = l.Autor.Nombre,
                    NombreGenero = l.Genero.Nombre
                })
                .FirstOrDefaultAsync();
            return libro;
        }

        Task<List<int>> GetAllLibroIds()
        {
            var ids = _context.Libros
                .Select(l => l.Id)
                .ToListAsync();
            return ids;
        }

        Task<List<int>> ILibroService.GetAllLibroIds()
        {
            var ids = _context.Libros
                .Select(l => l.Id)
                .ToListAsync();
            return ids;
        }
    }
}
