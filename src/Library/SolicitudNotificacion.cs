using System.Collections.Generic;
using System.Timers;
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
        private static List<Usuario> usuarios = new List<Usuario>();
        public Timer aTimer {get; set;}
        public SolicitudNotificacion(){}

        /// <summary>
        /// Crea el Timer necesario para notificar.
        /// Se corre el evento Notificar cada 1 minuto.
        /// Al ser asíncrono no vamos a poder ver el mensaje
        /// a menos que agreguemos Console.ReadLine() al final
        /// de esta funcion y sea la hora exacta.
        /// </summary>
        public void crearSolicitud()
        {
            
            if(usuarios.Count == 0)
            {
                throw new Exception("No hay usuarios agregados para notificar!");
            }
            // Seteamos el timer con el evento
            aTimer = new Timer(60000);
            aTimer.Elapsed += Notificar;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        /// <summary>
        /// Notificar el usario en el momento dado.
        /// Importante: este metodo en el futuro implementara Programa Emisor
        /// para poder notificar tanto por conosla como por telegram.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void Notificar(Object source, ElapsedEventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            foreach (Usuario usuario in usuarios)
            {
                List<String> tareasPendiente = usuario.TareaPendiente(fechaActual);
                if(tareasPendiente.Count > 0)
                {
                    foreach (String tarea in tareasPendiente)
                    {
                        Console.WriteLine("Es hora de trabajar en: " + tarea);
                    }
                }
            }
        }

        public void AgregarNotificado(Usuario usuario)
        {
            if(usuario.diasNotificacion.Count > 0)
            {
                usuarios.Add(usuario);
            }
            else
            {
                throw new Exception("Usuario sin dias de notificacion");
            }
        }
    }
}