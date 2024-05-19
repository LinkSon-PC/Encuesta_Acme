using AutoMapper;
using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;

namespace Encuesta_Acme.Servicios
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EncuestaRespuestaDTO, EncuestaRespuesta>()
                .ForMember(x => x.CampoRespuestas, opciones => opciones.MapFrom(MapEncuestaCampoRespuesta));
            CreateMap<EncuestaRespuesta, EncuestaRespuestaDTO>()
                .ForMember(x => x.CampoRespuestas, opciones => opciones.MapFrom(MapEncuestaCampoRespuestDTO));
            CreateMap<EncuestaCampoRespuestaDTO, EncuestaCampoRespuesta>().ReverseMap();

            CreateMap<EncuestaDTO, Encuesta>()
                .ForMember(x => x.Campos, opciones => opciones.MapFrom(MapCampoDTOEncuesta));
            CreateMap<Encuesta, EncuestaDTO>();
            CreateMap<Campo, CampoDTO>().ReverseMap();
        }

        private List<EncuestaCampoRespuesta> MapEncuestaCampoRespuesta(EncuestaRespuestaDTO encuestaDTO, EncuestaRespuesta encuesta)
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
                    CampoId = campoRespuesta.CampoId,
                    Respuesta = campoRespuesta.Respuesta
                });
            }

            return resultado;
        }

        private List<Campo> MapCampoDTOEncuesta(EncuestaDTO encuestaDTO, Encuesta encuesta)
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
