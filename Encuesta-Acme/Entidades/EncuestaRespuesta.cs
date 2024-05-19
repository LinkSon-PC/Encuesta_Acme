using Encuesta_Acme.Models;

namespace Encuesta_Acme.Entidades
{
    public class EncuestaRespuesta
    {
        public int Id { get; set; }
        public int EncuestaId { get; set; }
        public Encuesta Encuesta { get; set; }
        public ICollection<EncuestaCampoRespuesta> CampoRespuestas { get; set; }
    }
}
