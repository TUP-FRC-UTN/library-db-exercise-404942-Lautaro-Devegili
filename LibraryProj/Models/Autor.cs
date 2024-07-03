namespace LibraryProj.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
