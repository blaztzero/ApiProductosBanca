using ApiUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }          // ✅ Tabla Productos
        public DbSet<UsuarioProducto> UsuarioProducto { get; set; } // ✅ Tabla UsuarioProducto

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar clave primaria compuesta para UsuarioProducto
            modelBuilder.Entity<UsuarioProducto>()
                .HasKey(up => new { up.Id_Usuario, up.Id_Producto });

            // Configurar relaciones opcionales de navegación
            modelBuilder.Entity<UsuarioProducto>()
                .HasOne(up => up.Usuario)
                .WithMany()
                .HasForeignKey(up => up.Id_Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioProducto>()
                .HasOne(up => up.Producto)
                .WithMany()
                .HasForeignKey(up => up.Id_Producto)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
