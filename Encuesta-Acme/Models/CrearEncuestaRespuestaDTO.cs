namespace Encuesta_Acme.Models
{
    public class VerEncuestaRespuestaDTO
    {
        public int Id { get; set; }
        public ICollection<VerEncuestaCampoRespuestaDTO> CampoRespuestas { get; set; }
    }
}
