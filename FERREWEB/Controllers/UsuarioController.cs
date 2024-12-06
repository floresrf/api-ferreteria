using FERREWEB.Data.Services;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FERREWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("add-usuario")]
        public IActionResult AddMarca([FromBody] UsuarioVM usuario)
        {
            try
            {
                var newUsuario = _usuarioService.AddUsuario(usuario);
                return Created(nameof(AddMarca), newUsuario);
            }
            catch (NameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre del usuario: {ex.MarcaName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-usuario-by-id/{id}")]
        public IActionResult GetCarroById(int id)
        {
            var _response = _usuarioService.GetUsuarioById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-usuario-by-id/{id}")]
        public IActionResult DeleteMarcaById(int id)
        {
            try
            {
                _usuarioService.DeleteUsuarioById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
