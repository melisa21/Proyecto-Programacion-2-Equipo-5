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
        public Timer aTimer {get; private set;}
        public SolicitudNotificacion()
        {
            pEmisor = ProgramaEmisor.GetInstancia();
            this.crearSolicitud();
        }

        /// <summary>
        /// Crea el Timer necesario para notificar.
        /// </summary>
        private void crearSolicitud()
        {
            // Seteamos el timer con el evento
            aTimer = new Timer(this.Notificar, null, 60000, 60000);
        }
        /// <summary>
        /// Notificar los usarios del programa en el momento dado.
        /// </summary>
        /// <param name="source"></param>
        private void Notificar(Object source)
        {
            DateTime fechaActual = DateTime.Now;
            List<Usuario> usuarios = pEmisor.UsuariosDelPrograma;
            
            if (usuarios != null && usuarios.Count > 0)
            {
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
        }
    }
}