using AutoMapper;
using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;
using Encuesta_Acme.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Encuesta_Acme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaService encuestaService;
        private readonly UserManager<IdentityUser> userManager;

        public EncuestaController(IEncuestaService encuestaService, UserManager<IdentityUser> userManager)
        {            
            this.encuestaService = encuestaService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncuestaDTO>>> Get()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value.ToString();
            var usuario = await userManager.FindByEmailAsync(email);

            var encuestas = await encuestaService.Get(usuario.Id);
            return Ok(encuestas);
        }

        [HttpGet("respuestas/{id:int}")]
        public async Task<ActionResult<List<EncuestaRespuestaDTO>>> GetEncuestasRespuestas(int id)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value.ToString();
            var usuario = await userManager.FindByEmailAsync(email);

            var encuesta = await encuestaService.GetRespuestasById(id, usuario.Id);
            if (encuesta == null) { return NotFound(); }
            return Ok(encuesta);
        }

        [HttpGet("{id:int}", Name = "ObtenerPorId")]
        public async Task<ActionResult<EncuestaDTO>> GetByID(int id)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value.ToString();
            var usuario = await userManager.FindByEmailAsync(email);

            var encuesta = await encuestaService.GetById(id, usuario.Id);
            if (encuesta == null)
                return NotFound();

            return Ok(encuesta);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EncuestaDTO>> Actualizar(int id, [FromBody] ModificarEncuestaDTO modificarEncuesta)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value.ToString();
            var usuario = await userManager.FindByEmailAsync(email);

            try
            {
                await encuestaService.Update(id, usuario.Id, modificarEncuesta);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value.ToString();
            var usuario = await userManager.FindByEmailAsync(email);

            try
            {
                await encuestaService.Delete(id, usuario.Id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearEncuestaDTO encuestaDTO)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value.ToString();
            var usuario = await userManager.FindByEmailAsync(email);


            if (encuestaDTO == null)
                return BadRequest();

            var resultadoId = await encuestaService.Post(encuestaDTO, usuario.Id);

            return CreatedAtRoute("ObtenerPorId", new {id = resultadoId}, encuestaDTO);
        }

    }
}
