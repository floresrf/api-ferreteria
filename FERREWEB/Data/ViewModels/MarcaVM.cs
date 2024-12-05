using System.Collections.Generic;
using FERREWEB.Data.Models;

namespace FERREWEB.Data.ViewModels
{
    public class MarcaVM
    {
        public string NombreMarca { get; set; }
    }

    public class MarcawithProductosVM
    {
        public string NombreMarca { get; set; }
        public List<MarcaProductoVM> Productos { get; set; }
    }

    public class MarcaProductoVM
    {
        public string NombreProducto { get; set; }
        public int Costo { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }
}
