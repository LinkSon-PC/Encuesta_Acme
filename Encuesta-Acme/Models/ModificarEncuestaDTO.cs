using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Models
{
    public class ModificarEncuestaDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
