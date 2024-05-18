using AutoMapper;
using Encuesta_Acme.Models;

namespace Encuesta_Acme.Servicios
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Encuesta, EncuestaDTO>().ReverseMap();
            CreateMap<Campo, CampoDTO>().ReverseMap();
        }
    }
}
