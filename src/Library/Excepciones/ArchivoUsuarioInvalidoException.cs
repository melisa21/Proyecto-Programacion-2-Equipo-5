using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    internal class ArchivoUsuarioInvalidoException : Exception
    {
        public ArchivoUsuarioInvalidoException()
        {
        }

        public ArchivoUsuarioInvalidoException(string message) : base(message)
        {
        }

        public ArchivoUsuarioInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArchivoUsuarioInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}