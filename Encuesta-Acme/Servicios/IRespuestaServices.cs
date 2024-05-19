using Encuesta_Acme.Models;
using Encuesta_Acme.Entidades;

namespace Encuesta_Acme.Servicios
{
    public interface IRespuestaServices
    {
        public Task<Encuesta> GetById(int id);
        public Task<int> Post(EncuestaRespuestaDTO encuestaRespuestaDTO);
        public Task<IEnumerable<EncuestaRespuestaDTO>> GetRespuestasById(int id);
        public Task<EncuestaRespuestaDTO> GetRespuestaById(int id);
        Task<bool> ValidarExisteEncuesta(EncuestaRespuestaDTO respuestaDTO);
    }
}
