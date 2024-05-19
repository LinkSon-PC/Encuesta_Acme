using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Models
{
    public class EncuestaDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public List<CampoDTO> Campos { get; set; }
    }
}
