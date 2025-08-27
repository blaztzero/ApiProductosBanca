using Microsoft.AspNetCore.Mvc;
using ApiUsuarios.DTOs;
using ApiUsuarios.Services;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioProductoController : ControllerBase
    {
        private readonly IUsuarioProductoService _service;

        public UsuarioProductoController(IUsuarioProductoService service)
        {
            _service = service;
        }

        [HttpPost("listar")]
        public async Task<IActionResult> ListarProductos([FromBody] UsuarioProductoRequestDto request)
        {
            var productos = await _service.GetProductosUsuarioAsync(request.User_Name, request.Pass);
            return Ok(productos);
        }

        [HttpPost("asignar")]
        public async Task<IActionResult> AsignarProducto([FromBody] UsuarioProductoRequestDto request)
        {
            if (!request.IdProducto.HasValue) return BadRequest("Debe indicar IdProducto");

            var result = await _service.AsignarProductoAsync(request.User_Name, request.Pass, request.IdProducto.Value);
            if (!result) return Unauthorized("Usuario no válido o producto no existe");

            return Ok("Producto asignado correctamente");
        }

        [HttpPost("quitar")]
        public async Task<IActionResult> QuitarProducto([FromBody] UsuarioProductoRequestDto request)
        {
            if (!request.IdProducto.HasValue) return BadRequest("Debe indicar IdProducto");

            var result = await _service.QuitarProductoAsync(request.User_Name, request.Pass, request.IdProducto.Value);
            if (!result) return Unauthorized("Usuario no válido o producto no existe");

            return Ok("Producto quitado correctamente");
        }
    }
}
