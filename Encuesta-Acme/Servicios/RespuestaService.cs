using AutoMapper;
using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Servicios
{
    public class RespuestaService : IRespuestaServices
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public RespuestaService(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Post(CrearEncuestaRespuestaDTO respuestaDTO)
        {
            var encuesta = await context.Encuestas
            .Include(s => s.Campos)
            .FirstOrDefaultAsync(s => s.Id == respuestaDTO.EncuestaId);

            if (encuesta == null)
            {
                throw new KeyNotFoundException("Encuesta no encontrada");
            }

            var encuestaCampoIds = encuesta.Campos.Select(f => f.Id).ToHashSet();
            var campoRespuestasDict = respuestaDTO.CampoRespuestas.ToDictionary(fr => fr.CampoId);

            foreach (var campo in encuesta.Campos)
            {
                // Verificar si el campo requerido está presente en la petición
                if (campo.Requerido &&
                    (!campoRespuestasDict.ContainsKey(campo.Id)
                        || string.IsNullOrEmpty(campoRespuestasDict[campo.Id].Respuesta)))
                {
                    throw new ValidationException($"Campo `{campo.Nombre}` es requerido.");
                }
            }

            foreach (var fieldResponseDto in respuestaDTO.CampoRespuestas)
            {
                if (!encuestaCampoIds.Contains(fieldResponseDto.CampoId))
                {
                    throw new ValidationException($"Campo ID {fieldResponseDto.CampoId} no pertenece a la encuesta.");
                }

                var field = encuesta.Campos.First(f => f.Id == fieldResponseDto.CampoId);

                if (!ValidarCampoRespuestaResponse(field.TipoCampo, fieldResponseDto.Respuesta))
                {
                    throw new ValidationException($"Respuesta del campo `{field.TipoCampo}` no es del tipo `{field.TipoCampo}`.");
                }
            }


            var encuestaRespuesta = mapper.Map<EncuestaRespuesta>(respuestaDTO);
            context.EncuestaRespuestas.Add(encuestaRespuesta);
            await context.SaveChangesAsync();
            return encuestaRespuesta.Id;
        }

        public async Task<Encuesta> GetById(int id)
        {
            var encuesta = await context.Encuestas
                .Include(x => x.Campos)
                .FirstOrDefaultAsync(e => e.Id == id);

            return encuesta;
        }

        public async Task<EncuestaRespuestaDTO> GetRespuestaById(int id)
        {
            var respuesta = await context.EncuestaRespuestas
                .Include(e => e.CampoRespuestas)
                .FirstOrDefaultAsync(e => e.Id == id);

            var encuestaRespuestaDTO = mapper.Map<EncuestaRespuestaDTO>(respuesta);
            return encuestaRespuestaDTO;
        }


        private bool ValidarCampoRespuestaResponse(TipoCampo tipoCampo, string response)
        {
            switch (tipoCampo)
            {
                case TipoCampo.Text:
                    return true; // Todo texto es valido
                case TipoCampo.Number:
                    return int.TryParse(response, out _); // Validar si la respuesta es un numero valido
                case TipoCampo.Date:
                    return DateTime.TryParse(response, out _); // Validar si la respuesta es una fecha valida
                default:
                    return false;
            }
        }
    }
}
