using System.Collections.Generic;
using FERREWEB.Data.Models;

namespace FERREWEB.Data.ViewModels
{
    public class CategoriaVM
    {
        public string NombreCategoria { get; set; }
    }

    public class CategoriawithProductosVM
    {
        public string NombreCategoria { get; set; }
        public List<CategoriaProductoVM> Productos { get; set; }
    }

    public class CategoriaProductoVM
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }
}
