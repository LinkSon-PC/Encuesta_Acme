using Encuesta_Acme.Entidades;

namespace Encuesta_Acme.Models
{
    public class CampoDTO
    {
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public bool Requerido { get; set; }
        public TipoCampo TipoCampo { get; set; }
    }
}
