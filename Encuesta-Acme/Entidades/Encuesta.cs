using Microsoft.AspNetCore.Identity;

namespace Encuesta_Acme.Entidades

{
    public class Encuesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Campo> Campos { get; set; }
        public ICollection<EncuestaRespuesta> EncuestaRespuestas { get; set; }
        public string UsuarioId { get; set; }
        public IdentityUser Usuario { get; set; }
    }
}
