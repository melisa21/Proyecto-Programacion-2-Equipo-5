using System.Collections.Generic;
using System.Threading;
using System;
namespace Library
{
    public class SolicitudNotificacion
    {
        /// <summary>
        /// Esta clase se encarga de notificar al usuario
        /// cuando debe enviar una cierta entrada de la bitacora y
        /// lo hace en un proceso asíncrono.
        ///  
        /// Importante: esta clase implementara ProgramaEmisor
        /// en un futuro para enviar mensajes.
        /// </summary>
        private static ProgramaEmisor pEmisor;
        private List<Usuario> usuarios = new List<Usuario>();
        public Timer aTimer {get; private set;}
        public SolicitudNotificacion()
        {
            pEmisor = ProgramaEmisor.GetInstancia();
        }

        /// <summary>
        /// Crea el Timer necesario para notificar.
        /// </summary>
        public void crearSolicitud()
        {
            
            if(usuarios.Count == 0)
            {
                throw new SolicitudNotificacionException("No hay usuarios agregados para notificar!");
            }
            // Seteamos el timer con el evento
            aTimer = new Timer(this.Notificar, null, 1, 60000);
        }
        /// <summary>
        /// Notificar el usario en el momento dado.
        /// Importante: este metodo en el futuro implementara Programa Emisor
        /// para poder notificar tanto por conosla como por telegram.
        /// </summary>
        /// <param name="source"></param>
        private void Notificar(Object source)
        {
            DateTime fechaActual = DateTime.Now;
            foreach (Usuario usuario in usuarios)
            {
                List<DiaNotificacion> tareasPendiente = usuario.TareasPendientes(fechaActual);
                if(tareasPendiente.Count > 0)
                {
                    foreach (DiaNotificacion tarea in tareasPendiente)
                    {
                        pEmisor.EnviarMensajeNotificacion(usuario.IDContacto, tarea.Tipo);
                    }
                }
            }
        }
        /// <summary>
        /// Agregar usuario a la lista de personas a notificar
        /// solo si tiene ya agregados los dias de notificacion
        /// </summary>
        /// <param name="usuario"></param>
        public void AgregarNotificado(Usuario usuario)
        {
            if(usuario.diasNotificacion != null && usuario.diasNotificacion.Count > 0)
            {
                usuarios.Add(usuario);
            }
            else
            {
                throw new SolicitudNotificacionException("Usuario sin dias de notificacion");
            }
        }
    }
}