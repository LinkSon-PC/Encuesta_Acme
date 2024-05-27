using Encuesta_Acme.Entidades;

namespace Encuesta_Acme.Models
{
    public class VerCampoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public bool Requerido { get; set; }
    }
}
