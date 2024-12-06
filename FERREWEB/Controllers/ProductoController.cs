using FERREWEB.Data.Models;
using FERREWEB.Data.Services;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FERREWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost("add-producto")]
        public IActionResult AddProducto([FromBody] ProductoVM marca)
        {
            try
            {
                var newMarca = _productoService.AddProduct(marca);
                return Created(nameof(AddProducto), newMarca);
            }
            catch (NameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre del producto: {ex.MarcaName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-producto-by-id/{id}")]
        public IActionResult GetProductoById(int id)
        {
            var _response = _productoService.GetProductById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update-producto-by-id/{id}")]
        public IActionResult UpdateCarroById(int id, [FromBody] ProductoVM carro)
        {
            var updatecarro = _productoService.ModifyProduct(id, carro);
            return Ok(updatecarro);
        }

        [HttpDelete("delete-producto-by-id/{id}")]
        public IActionResult DeleteProductoById(int id)
        {
            try
            {
                _productoService.DeleteProductoById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
