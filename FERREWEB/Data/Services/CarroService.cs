using FERREWEB.Data.Models;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FERREWEB.Data.Services
{
    public class CarroService
    {
        private AppDbContext _context;

        public CarroService(AppDbContext context)
        {
            _context = context;
        }

        //Metodo crear Carro
        public Carro AddCarro([FromBody]CarroVM carro)
        {
            var _carro = new Carro()
            {
                idProducto = carro.idProducto,
                idUsuario = carro.idUsuario
            };
            _context.Carros.Add(_carro);
            _context.SaveChanges();

            return _carro;
        }
        
        public Carro GetCarroById(int id) => _context.Carros.FirstOrDefault(n => n.idCarro == id);

        public Carro ModifyCarro(int idcarro,CarroVM carro)
        {
            var _carro = _context.Carros.FirstOrDefault(n => n.idCarro == idcarro);
            if (_carro != null)
            {
                _carro.idUsuario = Convert.ToInt32(carro.idUsuario);
                _carro.idProducto = Convert.ToInt32(carro.idProducto);

                _context.SaveChanges();
            }
            return _carro;
        }

        internal void DeleteCarroById(int id)
        {
            var _carro = _context.Carros.FirstOrDefault(n => n.idCarro == id);
            if (_carro != null)
            {
                _context.Carros.Remove(_carro);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El carro con el Id: {id} no existe");
            }
        }
    }
}
