using AutoMapper;
using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Servicios
{
    public class EncuestaService : IEncuestaService
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public EncuestaService(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EncuestaDTO>> Get(string usuarioId)
        {
            var encuestas = await context.Encuestas
                .Include(x => x.Campos)
                .Where(x => x.UsuarioId == usuarioId)
                .ToListAsync();

            return mapper.Map<List<EncuestaDTO>>(encuestas);
        }

        public async Task<EncuestaDTO> GetById(int id, string usuarioId)
        {
            var encuesta = await context.Encuestas
                .Include(x => x.Campos)
                .Where(x => x.UsuarioId == usuarioId)
                .FirstOrDefaultAsync(e => e.Id == id);

            var encuestaDTO = mapper.Map<EncuestaDTO>(encuesta);
            return encuestaDTO;
        }

        public async Task<IEnumerable<EncuestaRespuestaDTO>> GetRespuestasById(int id, string usuarioId)
        {
            var respuesta = await context.EncuestaRespuestas
                .Include(e => e.CampoRespuestas)
                .Include(r => r.Encuesta)
                .Where(e => e.EncuestaId == id && e.Encuesta.UsuarioId == usuarioId)
                .ToListAsync();
        
            var encuestasRespuestasDTO = mapper.Map<List<EncuestaRespuestaDTO>>(respuesta);
            return encuestasRespuestasDTO;
        }


        public async Task Update(int id, string usuarioId, ModificarEncuestaDTO modificarEncuestaDTO)
        {
            var encuesta = await context.Encuestas
                .Where(e => e.Id == id && e.UsuarioId == usuarioId)
                .FirstOrDefaultAsync();

            if (encuesta == null)
                throw new KeyNotFoundException("Encuesta no encontrada");

            encuesta.Nombre = modificarEncuestaDTO.Nombre;
            encuesta.Descripcion = modificarEncuestaDTO.Descripcion;
            context.Update(encuesta);
            await context.SaveChangesAsync();

        }

        public async Task Delete(int id, string usuarioId)
        {
            var encuesta = await context.Encuestas
                .Include(x => x.Campos)
                .Where(x => x.UsuarioId == usuarioId)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (encuesta == null)
                throw new KeyNotFoundException("Encuesta no encontrada");

            context.Remove(new Encuesta() { Id = encuesta.Id });
            await context.SaveChangesAsync();
        }
        public async Task<int> Post(CrearEncuestaDTO encuestaDTO, string usuarioId)
        {
            var encuesta = mapper.Map<Encuesta>(encuestaDTO);
            encuesta.UsuarioId = usuarioId;

            context.Encuestas.Add(encuesta);
            await context.SaveChangesAsync();
            return encuesta.Id;
        }
    }
}
