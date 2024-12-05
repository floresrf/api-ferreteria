using FERREWEB.Data.Models;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;
using System.Text.RegularExpressions;

namespace FERREWEB.Data.Services
{
    public class ProductoService
    {
        private AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        //metodo crear Marca
        public Producto AddMarca(ProductoVM marca)
        {
            if (StringStartsWithNumber(marca.NombreProducto))
                throw new NameException("El nombre empieza con un número",
                marca.NombreProducto);

            var _marca = new Producto()
            {
                NombreProducto = marca.NombreProducto,
                Costo = marca.Costo,
                Imagen = marca.Imagen,
                Stock = marca.Stock
            };
            _context.Productos.Add(_marca);
            _context.SaveChanges();

            return _marca;
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
