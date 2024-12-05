using System;

namespace FERREWEB.Exceptions
{
    public class NameException : Exception
    {
        public string MarcaName { get; set; }

        public NameException()
        {

        }

        public NameException(string message) : base(message)
        {

        }

        public NameException(string message, Exception inner) : base(message, inner)
        {

        }

        public NameException(string message, string marcaName) : this(message)
        {
            MarcaName = marcaName;
        }
    }
}
