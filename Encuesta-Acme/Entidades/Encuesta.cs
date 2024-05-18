namespace Encuesta_Acme.Models
{
    public class Encuesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public ICollection<Campo> Campos { get; set; }
    }
}
