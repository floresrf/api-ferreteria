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
    public class CategoriaService
    {
        private AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        //metodo crear Categoria
        public Categoria AddCategoria(CategoriaVM categoria)
        {
            if(StringStartsWithNumber(categoria.NombreCategoria)) 
                throw new NameException("El nombre empieza con un número",
                categoria.NombreCategoria);

            var _categoria = new Categoria()
            {
                NombreCategoria = categoria.NombreCategoria
            };
            _context.Categorias.Add(_categoria);
            _context.SaveChanges();

            return _categoria;
        }

        //Obtener por ID
        public Categoria GetCategoriaByID(int id) => _context.Categorias.FirstOrDefault(n => n.idCategoria == id);
        public CategoriawithProductosVM GetCategoriaData(int marcaId)
        {
            var _categoriaData = _context.Categorias.Where(n => n.idCategoria == marcaId)
                .Select(n => new CategoriawithProductosVM()
                {
                    NombreCategoria = n.NombreCategoria,
                    Productos = n.ProductoRef.Select(n => new CategoriaProductoVM()
                    {
                        NombreProducto = n.NombreProducto,
                        Costo = n.Costo,
                        Imagen = n.Imagen,
                        Stock = n.Stock
                    }).ToList()
                }).FirstOrDefault();
            return _categoriaData;
        }

        internal void DeleteCategoriaById(int id)
        {
            var _categoria = _context.Categorias.FirstOrDefault(n => n.idCategoria == id);
            if(_categoria != null)
            {
                _context.Categorias.Remove(_categoria);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La categoria con el Id: {id} no existe");
            }
        }
        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }    
}
