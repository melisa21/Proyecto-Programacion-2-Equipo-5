using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    public class SolicitudNotificacionException : Exception
    {
        public SolicitudNotificacionException()
        {
        }

        public SolicitudNotificacionException(string message) : base(message)
        {
        }

        public SolicitudNotificacionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SolicitudNotificacionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}