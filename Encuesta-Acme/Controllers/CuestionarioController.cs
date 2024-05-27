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
        private readonly IRespuestaServices respuestaServices;

        public CuestionarioController(IRespuestaServices respuestaServices)
        {
            this.respuestaServices = respuestaServices;
        }

        [HttpGet("respuesta/{id:int}", Name = "ObtenerEncuestaRepuestaPorId")]
        public async Task<ActionResult<EncuestaRespuestaDTO>> GetRespuesta(int id)
        {
            var respuesta = await respuestaServices.GetRespuestaById(id);
            if (respuesta == null) { return NotFound(); }
            return respuesta;
        }

        [HttpGet("{id:int}", Name = "verEncuesta")]
        public async Task<ActionResult<VerEncuestaDTO>> GetEncuesta(int id)
        {
            try
            {
                var encuesta = await respuestaServices.GetById(id);
                if (encuesta == null) { return NotFound(); }
                return Ok(encuesta);
            }catch (KeyNotFoundException e) { 
                return NotFound(e.Message);
            }
        }

        [HttpPost("{id:int}", Name = "responderCuestionario")]
        public async Task<ActionResult> Post(int id, [FromBody] CrearEncuestaRespuestaDTO respuestaDTO)
        {
            if((respuestaDTO == null) || (id != respuestaDTO.EncuestaId)) {
                return BadRequest("ID encuesta incorrecto"); 
            }

            try
            {
                var encuestaId = await respuestaServices.Post(respuestaDTO);

                return CreatedAtRoute("verEncuesta", new { id = encuestaId }, respuestaDTO);
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
