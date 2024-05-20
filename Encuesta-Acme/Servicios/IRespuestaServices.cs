using Encuesta_Acme.Models;
using Encuesta_Acme.Entidades;

namespace Encuesta_Acme.Servicios
{
    public interface IRespuestaServices
    {
        public Task<Encuesta> GetById(int id);
        public Task<int> Post(CrearEncuestaRespuestaDTO encuestaRespuestaDTO);
        public Task<EncuestaRespuestaDTO> GetRespuestaById(int id);
    }
}
