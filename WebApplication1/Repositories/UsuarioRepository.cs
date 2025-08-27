using ApiUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ApiUsuarios.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync() =>
        await _context.Usuarios.ToListAsync();

    public async Task<Usuario?> GetByIdAsync(int id) =>
        await _context.Usuarios.FindAsync(id);

    public async Task AddAsync(Usuario usuario)
    {
        usuario.Fecha_Creacion = DateTime.Now;
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        usuario.Fecha_Modificacion = DateTime.Now;
        _context.Usuarios.Update(usuario);
        var user = await _context.Usuarios.ToListAsync();
        var query = user.Where(q => q.Id_Usuario > 1).ToList();
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
      
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
    // ✅ Nuevo método: buscar por userName y pass
    public async Task<Usuario?> GetByCredentialsAsync(string userName, string password) =>
        await _context.Usuarios
            .FirstOrDefaultAsync(u => u.User_Name == userName && u.Pass == password);
}
