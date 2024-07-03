using LibraryProj.DTOs;
using LibraryProj.Models;
using LibraryProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet("GetLibros")]
        public async Task<ActionResult<List<GetLibroDTO>>> GetLibros()
        {
            return await _libroService.GetAllLibros();
        }

        [HttpPost("CreateLibro")]
        public async Task<ActionResult<bool>> CreateLibro(CreateLibroDTO libro)
        {
            var seCreo = _libroService.CreateLibro(libro);
            if (seCreo.Result)
            {
                return Ok("Libro creado correctamente");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el libro");
        }

        [HttpPut("UpdateLibro")]
        public async Task<ActionResult<bool>> UpdateLibro(UpdateLibroDTO libro)
        {
            var seActualizo = _libroService.UpdateLibro(libro);
            if (seActualizo.Result)
            {
                return Ok("Libro actualizado correctamente");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error en controller al actualizar el libro.");
        }

        [HttpDelete("DeleteLibro/{id}")]
        public async Task<ActionResult<bool>> DeleteLibro(int id)
        {
            var seElimino = _libroService.DeleteLibro(id);
            if (seElimino.Result)
            {
                return Ok("Libro eliminado correctamente");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el libro");
        }

        [HttpGet("GetAutores")]
        public async Task<ActionResult<List<GetAutorDTO>>> GetAutores()
        {
            return await _libroService.GetAllAutores();
        }

        [HttpGet("GetGeneros")]
        public async Task<ActionResult<List<GetGeneroDTO>>> GetGeneros()
        {
            return await _libroService.GetAllGeneros();
        }

        [HttpGet("GetLibroById/{id}")]
        public async Task<ActionResult<UpdateLibroDTO>> GetLibroById(int id)
        {
            var libro = _libroService.GetLibroById(id);
            if (libro.Result != null)
            {
                return libro.Result;
            }
            return StatusCode(StatusCodes.Status404NotFound, "Libro no encontrado");
        }

        [HttpGet("GetAllLibroIds")]
        public async Task<ActionResult<List<int>>> GetAllLibroIds() 
        {
            return await _libroService.GetAllLibroIds();
        }


    }
}
