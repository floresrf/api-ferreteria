using System;

namespace CREAR_API.Exceptions
{
    public class MarcaNameException : Exception
    {
        public string MarcaName { get; set; }

        public MarcaNameException()
        {

        }

        public MarcaNameException(string message) : base(message)
        {

        }

        public MarcaNameException(string message, Exception inner) : base(message, inner)
        {

        }

        public MarcaNameException(string message, string marcaName) : this(message)
        {
            MarcaName = marcaName;
        }
    }
}
