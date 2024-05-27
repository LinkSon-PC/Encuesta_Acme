using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Models
{
    public class ResponderEncuestaCreadaDTO
    {
        public CrearEncuestaDTO crearEncuesta { get; set; }
        public string Url { get; set; }
    }
}
