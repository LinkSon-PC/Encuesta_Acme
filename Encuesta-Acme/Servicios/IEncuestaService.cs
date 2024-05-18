using Encuesta_Acme.Models;

namespace Encuesta_Acme.Servicios
{
    public interface IEncuestaService
    {
        public Task<IEnumerable<Encuesta>> Get();
        public Task<Encuesta> GetById(int id);
        public void Post(EncuestaDTO encuestaDTO);
    }
}
