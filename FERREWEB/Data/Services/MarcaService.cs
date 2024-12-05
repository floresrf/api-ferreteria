using FERREWEB.Exceptions;
using FERREWEB.Data;
using FERREWEB.Data.Models;
using FERREWEB.Data.ViewModels;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.RegularExpressions;


namespace FERREWEB.Data.Services
{
    public class MarcaService
    {
        private AppDbContext _context;

        public MarcaService(AppDbContext context)
        {
            _context = context;
        }

        //metodo crear Marca
        public Marca AddMarca(MarcaVM marca)
        {
            if(StringStartsWithNumber(marca.NombreMarca)) 
                throw new NameException("El nombre empieza con un número",
                marca.NombreMarca);

            var _marca = new Marca()
            {
                NombreMarca = marca.NombreMarca
            };
            _context.Marcas.Add(_marca);
            _context.SaveChanges();

            return _marca;
        }

        //Obtener por ID
        public Marca GetMarcaByID(int id) => _context.Marcas.FirstOrDefault(n => n.idMarca == id);
        public MarcawithProductosVM GetMarcaData(int marcaId)
        {
            var _marcaData = _context.Marcas.Where(n => n.idMarca == marcaId)
                .Select(n => new MarcawithProductosVM()
                {
                    NombreMarca = n.NombreMarca,
                    Productos = n.ProductoRef.Select(n => new MarcaProductoVM()
                    {
                        NombreProducto = n.NombreProducto,
                        Costo = n.Costo,
                        Imagen = n.Imagen,
                        Stock = n.Stock
                    }).ToList()
                }).FirstOrDefault();
            return _marcaData;
        }

        internal void DeleteMarcaById(int id)
        {
            var _marca = _context.Marcas.FirstOrDefault(n => n.idMarca == id);
            if(_marca != null)
            {
                _context.Marcas.Remove(_marca);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La marca con el Id: {id} no existe");
            }
        }
        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }    
}
