namespace ApiUsuarios.DTOs
{
    public class UsuarioProductoRequestDto
    {
        public string User_Name { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public int? IdProducto { get; set; } // null si solo quiere listar
    }
}
