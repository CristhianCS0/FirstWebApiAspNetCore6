namespace FirstWebApi.Entity
{
    public class Libro
    {
        public int id { get; set; }
        public int AutorId { get; set; }
        public string name { get; set; }
        public Autor Autor { get; set; }
    }
}
