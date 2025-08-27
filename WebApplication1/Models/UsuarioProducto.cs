using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUsuarios.Models
{
    [Table("UsuarioProducto")]
    public class UsuarioProducto
    {
        [Key, Column(Order = 0)]
        public int Id_Usuario { get; set; }

        [Key, Column(Order = 1)]
        public int Id_Producto { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        // Opcionales: referencias de navegación para Entity Framework
        [ForeignKey("Id_Usuario")]
        public virtual Usuario? Usuario { get; set; }

        [ForeignKey("Id_Producto")]
        public virtual Producto? Producto { get; set; }
    }
}
