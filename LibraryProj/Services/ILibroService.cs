using LibraryProj.DTOs;

namespace LibraryProj.Services
{
    public interface ILibroService
    {
        Task<List<GetLibroDTO>> GetAllLibros();
        Task<bool> UpdateLibro(UpdateLibroDTO libro);
        Task<bool> DeleteLibro(int idlibro);
        Task<bool> CreateLibro(CreateLibroDTO libro);
        Task<List<GetAutorDTO>> GetAllAutores();
        Task<List<GetGeneroDTO>> GetAllGeneros();
        Task<UpdateLibroDTO> GetLibroById(int id);
        Task<List<int>> GetAllLibroIds();
    }
}
