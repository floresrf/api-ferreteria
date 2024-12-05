using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FERREWEB.Data.Services;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;

namespace FERREWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {       
        private readonly CategoriaService _categoriaService;
        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost("add-categoria")]
        public IActionResult AddCategoria([FromBody] CategoriaVM marca)
        {
            try
            {
                var newCategoria = _categoriaService.AddCategoria(marca);
                return Created(nameof(AddCategoria), newCategoria);
            }
            catch (NameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la marca: {ex.MarcaName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-categoria-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _categoriaService.GetCategoriaByID(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-categoria-by-id/{id}")]
        public IActionResult DeleteMarcaById(int id)
        {
            try
            {
                _categoriaService.DeleteCategoriaById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
