namespace FERREWEB.Data.ViewModels
{
    public class ProductoVM
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }

    public class ProductoDataVM
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public List<ProductowithCategoriaVM> Categoria { get; set; }
        public List<ProductowithMarcaVM> Marca { get; set; }
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
