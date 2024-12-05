namespace FERREWEB.Data.ViewModels
{
    public class UsuarioVM
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
    }

    public class UsuarioCarroVM
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public List<UsuariowithCarroVM> Carro { get; set; }
    }

    public class UsuariowithCarroVM
    {
        public int idProducto { get; set; }
    }
}
