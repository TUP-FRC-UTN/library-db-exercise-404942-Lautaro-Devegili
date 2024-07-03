namespace LibraryProj.DTOs
{
    public class GetLibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public String Autor { get; set; }
        public String Genero { get; set; }
    }
}
