namespace LibraryProj.DTOs
{
    public class CreateLibroDTO
    {
        public string Titulo { get; set; }
        public int ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int IdAutor { get; set; }
        public int IdGenero { get; set; }
    }
}
