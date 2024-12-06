using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FERREWEB.Data.Services;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;

namespace FERREWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {       
        private readonly CarroService _carroService;
        public CarroController(CarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpPost("add-carro")]
        public IActionResult AddCarro([FromBody] CarroVM carro)
        {            
            try
            {
                var newCarro = _carroService.AddCarro(carro);
                return Created(nameof(AddCarro), newCarro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-carro-by-id/{id}")]
        public IActionResult GetCarroById(int id)
        {
            var _response = _carroService.GetCarroById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update-carro-by-id/{id}")]
        public IActionResult UpdateCarroById(int id, [FromBody]CarroVM carro)
        {
            var updatecarro = _carroService.ModifyCarro(id, carro);
            return Ok(updatecarro);
        }

        [HttpDelete("delete-carro-by-id/{id}")]
        public IActionResult DeleteMarcaById(int id)
        {
            try
            {
                _carroService.DeleteCarroById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
