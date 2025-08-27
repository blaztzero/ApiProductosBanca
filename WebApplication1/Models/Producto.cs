using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUsuarios.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreProducto { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string DescripcionProducto { get; set; } = string.Empty;

        [Required]
        public bool Estado { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
