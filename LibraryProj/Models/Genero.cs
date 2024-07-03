namespace LibraryProj.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
