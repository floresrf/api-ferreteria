namespace FERREWEB.Data.Models
{
    public class Marca
    {
        public int idMarca { get; set; }
        public string NombreMarca { get; set; }

        //Relaciones
        public virtual ICollection<Producto> ProductoRef { get; set; }
    }
}
