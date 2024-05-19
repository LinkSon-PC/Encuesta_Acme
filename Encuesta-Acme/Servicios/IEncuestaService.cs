using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;

namespace Encuesta_Acme.Servicios
{
    public interface IEncuestaService
    {
        public Task<IEnumerable<EncuestaDTO>> Get(string usuarioId);
        public Task<EncuestaDTO> GetById(int id, string usuarioId);
        public Task Update(int id, string usuarioId, ModificarEncuestaDTO modificarEncuestaDTO);
        public Task<IEnumerable<EncuestaRespuestaDTO>> GetRespuestasById(int id, string usuarioId);
        public Task Delete(int id, string usuarioId);
        public Task<int> Post(CrearEncuestaDTO encuestaDTO, string usuarioId);
    }
}
