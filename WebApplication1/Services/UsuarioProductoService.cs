using ApiUsuarios.Models;
using ApiUsuarios.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Services
{
    public class UsuarioProductoService : IUsuarioProductoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IUsuarioProductoRepository _usuarioProductoRepository;

        public UsuarioProductoService(
            IUsuarioRepository usuarioRepository,
            IProductoRepository productoRepository,
            IUsuarioProductoRepository usuarioProductoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _productoRepository = productoRepository;
            _usuarioProductoRepository = usuarioProductoRepository;
        }

        // ✅ Listar productos de un usuario validando sus credenciales
        public async Task<IEnumerable<Producto>> GetProductosUsuarioAsync(string userName, string password)
        {
            var usuario = await _usuarioRepository.GetByCredentialsAsync(userName, password);
            if (usuario == null) return Enumerable.Empty<Producto>();

            var productos = await _usuarioProductoRepository.GetProductosByUsuarioIdAsync(usuario.Id_Usuario);
            return productos;
        }

        // ✅ Asignar producto a un usuario
        public async Task<bool> AsignarProductoAsync(string userName, string password, int idProducto)
        {
            var usuario = await _usuarioRepository.GetByCredentialsAsync(userName, password);
            if (usuario == null) return false;

            var producto = await _productoRepository.GetByIdAsync(idProducto);
            if (producto == null) return false;

            await _usuarioProductoRepository.AddAsync(usuario.Id_Usuario, idProducto);
            return true;
        }

        // ✅ Quitar producto a un usuario
        public async Task<bool> QuitarProductoAsync(string userName, string password, int idProducto)
        {
            var usuario = await _usuarioRepository.GetByCredentialsAsync(userName, password);
            if (usuario == null) return false;

            await _usuarioProductoRepository.DeleteAsync(usuario.Id_Usuario, idProducto);
            return true;
        }
    }
}
