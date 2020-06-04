using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    public class ListaDeDiasInvalidaException : Exception
    {
        public ListaDeDiasInvalidaException()
        {
        }

        public ListaDeDiasInvalidaException(string message) : base(message)
        {
        }

        public ListaDeDiasInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ListaDeDiasInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}