using ApiUsuarios.Models;

namespace ApiUsuarios.Repositories
{
    public interface IUsuarioProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductosByUsuarioIdAsync(int idUsuario);
        Task AddAsync(int idUsuario, int idProducto);
        Task DeleteAsync(int idUsuario, int idProducto);
    }
}
