using ApiUsuarios.Models;
using ApiUsuarios.Repositories;

namespace ApiUsuarios.Services;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetUsuariosAsync();
    Task<Usuario?> GetUsuarioAsync(int id);
    Task CrearUsuarioAsync(Usuario usuario);
    Task ActualizarUsuarioAsync(Usuario usuario);
    Task EliminarUsuarioAsync(int id);

    // Nuevo método para login
    Task<Usuario?> GetByCredentialsAsync(string userName, string password);
}
