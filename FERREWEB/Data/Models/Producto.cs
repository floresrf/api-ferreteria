using System.Security.Cryptography;

namespace FERREWEB.Data.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string NombreProducto { get ; set; }
        public string Costo { get; set; }
        public string Imagen { get; set; }
        public string Stock { get; set; }

        //Relaciones
        public int idCategoria { get; set; }
        public virtual Categoria CategoriaRef { get; set; }
        public int idMarca { get; set; }
        public virtual Marca MarcaRef { get; set; }
    }
}
