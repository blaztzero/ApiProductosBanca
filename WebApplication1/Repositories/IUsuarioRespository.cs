using ApiUsuarios.Models;

namespace ApiUsuarios.Repositories;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario?> GetByIdAsync(int id);
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(int id);
    // Nuevo método para login
    Task<Usuario?> GetByCredentialsAsync(string userName, string password);
}