using AutoMapper;
using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;

namespace Encuesta_Acme.Servicios
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CrearEncuestaRespuestaDTO, EncuestaRespuesta>()
                .ForMember(x => x.CampoRespuestas, opciones => opciones.MapFrom(MapEncuestaCampoRespuesta));
            CreateMap<EncuestaRespuesta, EncuestaRespuestaDTO>()
                .ForMember(x => x.CampoRespuestas, opciones => opciones.MapFrom(MapEncuestaCampoRespuestDTO));

            CreateMap<EncuestaRespuesta, VerEncuestaRespuestaDTO>();

            CreateMap<EncuestaCampoRespuestaDTO, EncuestaCampoRespuesta>().ReverseMap();
            CreateMap<EncuestaCampoRespuesta, VerEncuestaCampoRespuestaDTO>().ReverseMap();

            CreateMap<CrearEncuestaDTO, Encuesta>()
                .ForMember(x => x.Campos, opciones => opciones.MapFrom(MapCampoDTOEncuesta));
            CreateMap<Encuesta, EncuestaDTO>();
            CreateMap<Encuesta, VerEncuestaDTO>();
            CreateMap<ModificarEncuestaDTO, Encuesta>();
            CreateMap<Campo, CampoDTO>().ReverseMap();
            CreateMap<Campo, VerCampoDTO>().ReverseMap();

        }

        private List<EncuestaCampoRespuesta> MapEncuestaCampoRespuesta(CrearEncuestaRespuestaDTO encuestaDTO, EncuestaRespuesta encuesta)
        {
            var resultado = new List<EncuestaCampoRespuesta>();

            if (encuestaDTO == null) { return resultado; }

            foreach (var campoRespuesta in encuestaDTO.CampoRespuestas)
            {
                resultado.Add(new EncuestaCampoRespuesta()
                {
                    CampoId = campoRespuesta.CampoId,
                    Respuesta = campoRespuesta.Respuesta
                });
            }

            return resultado;
        }

        private List<EncuestaCampoRespuestaDTO> MapEncuestaCampoRespuestDTO(EncuestaRespuesta encuesta, EncuestaRespuestaDTO encuestaDTO)
        {
            var resultado = new List<EncuestaCampoRespuestaDTO>();

            if (encuesta == null) { return resultado; }

            foreach (var campoRespuesta in encuesta.CampoRespuestas)
            {
                resultado.Add(new EncuestaCampoRespuestaDTO()
                {
                    Id = campoRespuesta.Id,
                    CampoId = campoRespuesta.CampoId,
                    Respuesta = campoRespuesta.Respuesta
                });
            }

            return resultado;
        }

        private List<Campo> MapCampoDTOEncuesta(CrearEncuestaDTO encuestaDTO, Encuesta encuesta)
        {
            var resultado = new List<Campo>();

            if (encuestaDTO == null) { return resultado; }

            foreach (var campo in encuestaDTO.Campos)
            {
                resultado.Add(new Campo()
                {
                    Nombre = campo.Nombre,
                    Titulo = campo.Titulo,
                    Requerido = campo.Requerido,
                    TipoCampo = campo.TipoCampo
                });
            }

            return resultado;
        }
    }
}
