namespace FERREWEB.Data.ViewModels
{
    public class CarroVM
    {
        public int idCarro { get; set; }
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
    }

    public class CarroDetalles
    {
        public int idCarro { get; set; }
        public List<CarrowithUsuarioVM> Usuario { get; set; }
        public List<CarrowithProductoVM> Productos { get; set; }        
    }

    public class CarrowithProductoVM
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }

    public class CarrowithUsuarioVM
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
    }
}
