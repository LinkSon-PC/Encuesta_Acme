using AutoMapper;
using Encuesta_Acme.Models;
using Encuesta_Acme.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Encuesta_Acme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEncuestaService encuestaService;
        public List<Encuesta> AcmeList = new List<Encuesta>()
            {
                new Encuesta()
                {
                    Id = 1,
                    Nombre = "Encuesta 1",
                    Descripcion = "Descripcion 1"
                },
                new Encuesta()
                {
                    Id = 2,
                    Nombre = "Encuesta 2",
                    Descripcion = "Descripcion 2"
                },
                new Encuesta()
                {
                    Id = 3,
                    Nombre = "Encuesta 3",
                    Descripcion = "Descripcion 3"
                }
            };

        public EncuestaController(IMapper mapper, IEncuestaService encuestaService)
        {            
            this.mapper = mapper;
            this.encuestaService = encuestaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encuesta>>> Get()
        {
            var encuestas = await encuestaService.Get();
            return Ok(encuestas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Encuesta>> GetByID(int id)
        {
            var encuesta = await encuestaService.GetById(id);
            if (encuesta == null)
                return NotFound();

            return Ok(encuesta);
        }

        [HttpPost]
        public ActionResult Post([FromBody] EncuestaDTO encuestaDTO)
        {
            if (encuestaDTO == null)
                return BadRequest();

            var encuesta = mapper.Map<Encuesta>(encuestaDTO);
            encuesta.Id = AcmeList.Count() + 1;

            AcmeList.Add(encuesta);

            return Ok();
        }


    }
}
