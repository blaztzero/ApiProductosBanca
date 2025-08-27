using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Models;

public class Usuario
{
    [Key] // ✅ Marca esta propiedad como clave primaria
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ Auto-incremental
    public int Id_Usuario { get; set; }
    public string User_Name { get; set; } = string.Empty;
    public string Pass { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime Fecha_Creacion { get; set; }
    public DateTime? Fecha_Modificacion { get; set; }
}