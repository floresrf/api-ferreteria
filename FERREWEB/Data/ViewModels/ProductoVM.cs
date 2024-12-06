namespace FERREWEB.Data.ViewModels
{
    public class ProductoVM
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public int idCategoria { get; set; }
        public int idMarca { get; set; }
    }

    public class ProductoDataVM
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public List<ProductowithCategoriaVM> idCategoria { get; set; }
        public List<ProductowithMarcaVM> idMarca { get; set; }
    }

    public class ProductowithMarcaVM
    {
        public string NombreMarca { get; set; }
    }

    public class ProductowithCategoriaVM
    {
        public string NombreCategoria { get; set; }
    }
}
