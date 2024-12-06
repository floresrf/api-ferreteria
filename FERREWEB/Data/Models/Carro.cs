namespace FERREWEB.Data.Models
{
    public class Carro
    {
        public int idCarro { get; set; }               

        //Relaciones
        public int idUsuario { get; set; }
        public virtual Usuario UsuarioRef { get; set; }
        public int idProducto { get; set; }
        public virtual Producto ProductoRef { get; set; }
    }
}
