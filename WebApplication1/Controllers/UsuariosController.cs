using ApiUsuarios.DTOs;
using ApiUsuarios.Models;
using ApiUsuarios.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuariosController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _service.GetUsuariosAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var usuario = await _service.GetUsuarioAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuario usuario)
    {
        await _service.CrearUsuarioAsync(usuario);
        return CreatedAtAction(nameof(Get), new { id = usuario.Id_Usuario }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Usuario usuario)
    {
        if (id != usuario.Id_Usuario) return BadRequest();
        await _service.ActualizarUsuarioAsync(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.EliminarUsuarioAsync(id);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginDto loginDto)
    {
        var usuario = await _service.GetByCredentialsAsync(loginDto.User_Name, loginDto.Pass);
        if (usuario == null)
            return Unauthorized(new { message = "Usuario o contraseña incorrecta" });
        return Ok(usuario);
    }
}
