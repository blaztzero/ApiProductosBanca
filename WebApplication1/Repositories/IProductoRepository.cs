using ApiUsuarios.Models;

namespace ApiUsuarios.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int idProducto);
    }
}
