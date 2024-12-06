using FERREWEB.Data.Models;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

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
        public Producto AddProduct(ProductoVM marca)
        {
            if (StringStartsWithNumber(marca.NombreProducto))
                throw new NameException("El nombre empieza con un número",
                marca.NombreProducto);

            var _marca = new Producto()
            {
                NombreProducto = marca.NombreProducto,
                Costo = marca.Costo,
                Imagen = marca.Imagen,
                Stock = marca.Stock,        
                idCategoria = marca.idCategoria,
                idMarca = marca.idMarca
            };
            _context.Productos.Add(_marca);
            _context.SaveChanges();

            return _marca;
        }

        public Producto GetProductById(int id) => _context.Productos.FirstOrDefault(n => n.idProducto == id);

        public Producto ModifyProduct(int idcarro, ProductoVM carro)
        {
            var _carro = _context.Productos.FirstOrDefault(n => n.idProducto == idcarro);
            if (_carro != null)
            {
                _carro.NombreProducto = carro.NombreProducto;
                _carro.Costo = carro.Costo;
                _carro.Imagen = carro.Imagen;
                _carro.Stock = carro.Stock;
                _carro.idCategoria = carro.idCategoria;
                _carro.idMarca = carro.idMarca;

                _context.SaveChanges();
            }
            return _carro;
        }

        internal void DeleteProductoById(int id)
        {
            var _carro = _context.Productos.FirstOrDefault(n => n.idProducto == id);
            if (_carro != null)
            {
                _context.Productos.Remove(_carro);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El producto con el Id: {id} no existe");
            }
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
