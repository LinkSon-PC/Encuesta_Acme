namespace Encuesta_Acme.Models
{
    public class EncuestaCampoRespuestaDTO
    {
        public int Id { get; set; }
        public int CampoId { get; set; }
        public string Respuesta { get; set; }
        public bool Requerido { get; set; }
    }
}
