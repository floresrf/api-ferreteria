namespace FERREWEB.Data.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }       

        //Relaciones
        public int idCarro { get; set; }
        public virtual Carro CarroRef { get; set; }
    }
}
