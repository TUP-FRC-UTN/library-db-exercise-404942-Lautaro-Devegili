namespace LibraryProj.DTOs
{
    public class UpdateLibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int IdAutor { get; set; }
        public int IdGenero { get; set; }
        public string NombreAutor { get; set; }
        public string NombreGenero { get; set; }
    }
}
