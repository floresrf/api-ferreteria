using FERREWEB.Data.Models;
using FERREWEB.Data.ViewModels;
using FERREWEB.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FERREWEB.Data.Services
{
    public class UsuarioService
    {
        private AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        //Metodo crear Usuario
        public Usuario AddUsuario([FromBody] UsuarioVM usuario)
        {
            if (StringStartsWithNumber(usuario.NombreUsuario))
                throw new NameException("El nombre empieza con un número",
                usuario.NombreUsuario);

            var _usuario = new Usuario()
            {
                NombreUsuario = usuario.NombreUsuario
            };
            _context.Usuarios.Add(_usuario);
            _context.SaveChanges();

            return _usuario;
        }

        internal void DeleteUsuarioById(int id)
        {
            var _usuario = _context.Usuarios.FirstOrDefault(n => n.idUsuario == id);
            if (_usuario != null)
            {
                _context.Usuarios.Remove(_usuario);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El usuario con el Id: {id} no existe");
            }
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
