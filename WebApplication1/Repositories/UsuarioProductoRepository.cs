using ApiUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Repositories
{
    public class UsuarioProductoRepository : IUsuarioProductoRepository
    {
        private readonly AppDbContext _context;

        public UsuarioProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Obtener productos asignados a un usuario
        public async Task<IEnumerable<Producto>> GetProductosByUsuarioIdAsync(int idUsuario)
        {
            var productos = await _context.UsuarioProducto
                .Where(up => up.Id_Usuario == idUsuario && up.Estado == true)
                .Join(_context.Productos,
                      up => up.Id_Producto,
                      p => p.Id_Producto,
                      (up, p) => p)
                .ToListAsync();

            return productos;
        }

        // ✅ Asignar producto a un usuario
        public async Task AddAsync(int idUsuario, int idProducto)
        {
            // Verificar si ya existe
            var existente = await _context.UsuarioProducto
                .FirstOrDefaultAsync(up => up.Id_Usuario == idUsuario && up.Id_Producto == idProducto);

            if (existente == null)
            {
                _context.UsuarioProducto.Add(new UsuarioProducto
                {
                    Id_Usuario = idUsuario,
                    Id_Producto = idProducto,
                    Estado = true,
                    FechaCreacion = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }
            else if (existente.Estado == false)
            {
                // Reactivar si estaba inactivo
                existente.Estado = true;
                existente.FechaCreacion = DateTime.Now;
                _context.UsuarioProducto.Update(existente);
                await _context.SaveChangesAsync();
            }
        }

        // ✅ Quitar producto a un usuario (marcar como inactivo)
        public async Task DeleteAsync(int idUsuario, int idProducto)
        {
            var registro = await _context.UsuarioProducto
                .FirstOrDefaultAsync(up => up.Id_Usuario == idUsuario && up.Id_Producto == idProducto);

            if (registro != null)
            {
                registro.Estado = false;
                _context.UsuarioProducto.Update(registro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
