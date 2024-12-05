using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components;

using FERREWEB.Data.Services;
using FERREWEB.Data.ViewModels;
using CREAR_API.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FERREWEB.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {       
        private readonly MarcaService _marcaService;
        public MarcaController(MarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpPost("add-marca")]
        public IActionResult AddMarca([FromBody] MarcaVM marca)
        {
            try
            {
                var newMarca = _marcaService.AddMarca(marca);
                return Created(nameof(AddMarca), newMarca);
            }
            catch (MarcaNameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la marca: {ex.MarcaName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-marca-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _marcaService.GetMarcaByID(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
