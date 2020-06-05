using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    public class NombreVacioException : Exception
    {
        public NombreVacioException()
        {
        }

        public NombreVacioException(string message) : base(message)
        {
        }

        public NombreVacioException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NombreVacioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}