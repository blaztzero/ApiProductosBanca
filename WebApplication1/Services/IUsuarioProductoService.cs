using ApiUsuarios.Models;

namespace ApiUsuarios.Services
{
    public interface IUsuarioProductoService
    {
        Task<IEnumerable<Producto>> GetProductosUsuarioAsync(string userName, string password);
        Task<bool> AsignarProductoAsync(string userName, string password, int idProducto);
        Task<bool> QuitarProductoAsync(string userName, string password, int idProducto);
    }
}
