namespace Encuesta_Acme.Models
{
    public class CrearEncuestaRespuestaDTO
    {
        public int EncuestaId { get; set; }
        public ICollection<CrearEncuestaCampoRespuestaDTO> CampoRespuestas { get; set; }
    }
}
