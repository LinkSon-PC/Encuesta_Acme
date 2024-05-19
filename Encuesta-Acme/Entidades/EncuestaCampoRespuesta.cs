using Encuesta_Acme.Models;

namespace Encuesta_Acme.Entidades
{
    public class EncuestaCampoRespuesta
    {
        public int Id { get; set; }
        public int EncuestaRespuestaId { get; set; }
        public EncuestaRespuesta EncuestaRespuesta { get; set; }
        public int CampoId { get; set; }
        public Campo Campo { get; set; }
        public string Respuesta { get; set; }
    }
}
