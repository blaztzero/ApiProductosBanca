using ApiUsuarios.Models;
using ApiUsuarios.Repositories;

namespace ApiUsuarios.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Usuario>> GetUsuariosAsync() =>
        await _repository.GetAllAsync();

    public async Task<Usuario?> GetUsuarioAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task CrearUsuarioAsync(Usuario usuario) =>
        await _repository.AddAsync(usuario);

    public async Task ActualizarUsuarioAsync(Usuario usuario) =>
        await _repository.UpdateAsync(usuario);

    public async Task EliminarUsuarioAsync(int id) =>
        await _repository.DeleteAsync(id);

    // ✅ Nuevo método de login
    public async Task<Usuario?> GetByCredentialsAsync(string userName, string password) =>
        await _repository.GetByCredentialsAsync(userName, password);
}
