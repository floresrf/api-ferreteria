using System.Collections;

namespace FERREWEB.Data.Models
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public string NombreCategoria { get; set; }
        
        //Relaciones
        public virtual ICollection<Producto> ProductoRef { get; set; }
    }
}
