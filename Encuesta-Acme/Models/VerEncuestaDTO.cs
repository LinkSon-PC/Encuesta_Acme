using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Models
{
    public class VerEncuestaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<VerCampoDTO> Campos { get; set; }
    }
}
