using Ejercicio5Modulo3.Aplication.Responses;
using Ejercicio5Modulo3.Domain.Contracts;
using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio5Modulo3.Controllers
{
    [ApiController]
    [Route("/api/usuario")]
    public class UsuarioController : ControllerBase
    {
        
        private readonly IUsuarioService _usuarioService;
        
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("seed")]
        public async Task<ActionResult<string>>  Post()
        {
            try
            {
                await _usuarioService.Seed_Usuarios();
                return Ok("Usuarios creados");
            }
            catch (Exception e)
            {
                if (e is HttpRequestException)
                {
                    return BadRequest("Error al intentar conectar con el servidor");
                }
                else
                {
                    return BadRequest(e.Message);
                }
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<List<UsuarioResponse>>> Get(
                int? age,
                Genres? genre
            )
        {
                var usuarios = await _usuarioService.Get_Usuarios(
                    age, genre
                    );
                var mappedUsuarios = usuarios.Select(UsuarioResponse.FromEntity).ToList();
                
                return Ok(mappedUsuarios);
  
        }
    }
}