using AutoMapper;
using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;
using Encuesta_Acme.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;

namespace Encuesta_Acme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IRespuestaServices respuestaServices;

        public CuestionarioController(IMapper mapper, IRespuestaServices respuestaServices)
        {
            this.mapper = mapper;
            this.respuestaServices = respuestaServices;
        }

        [HttpGet("respuesta/{id:int}", Name = "ObtenerEncuestaRepuestaPorId")]
        public async Task<ActionResult<EncuestaRespuestaDTO>> GetRespuesta(int id)
        {
            var respuesta = await respuestaServices.GetRespuestaById(id);
            if (respuesta == null) { return NotFound(); }
            return respuesta;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Encuesta>> GetEncuesta(int id)
        {
            var encuesta = await respuestaServices.GetById(id);
            if (encuesta == null) { return NotFound(); }
            return Ok(encuesta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearEncuestaRespuestaDTO respuestaDTO)
        {
            try
            {
                var encuestaId = await respuestaServices.Post(respuestaDTO);

                return CreatedAtRoute("ObtenerEncuestaRepuestaPorId", new { id = encuestaId }, respuestaDTO);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
