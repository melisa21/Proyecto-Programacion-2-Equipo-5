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
        private static List<DiaNotificacion> dias;
        public Timer aTimer {get; set;}

        public SolicitudNotificacion(List<DiaNotificacion> data){
            dias = data;
        }
        /// <summary>
        /// Crea el Timer necesario para notificar.
        /// Se corre el evento Notificar cada 1 minuto.
        /// Al ser asíncrono no vamos a poder ver el mensaje
        /// a menos que agreguemos Console.ReadLine() al final
        /// de esta funcion y sea la hora exacta.
        /// </summary>
        public void crearSolicitud()
        {
            
            if(dias.Count == 0)
                return;
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
            foreach (DiaNotificacion diaNot in dias)
            {
                if(EsMomentoDeNotificar(diaNot, DateTime.Now))
                {
                    Console.WriteLine($"Es hora de trabajar en la {(DiaNotificacion.TipoEntrada)diaNot.Tipo}!");
                }
            }
        }
        /// <summary>
        /// Verificar que es el momento de notificacion.
        /// </summary>
        /// <param name="diaNot"></param>
        /// <param name="diaYHoraActual"></param>
        public static bool EsMomentoDeNotificar(DiaNotificacion diaNot, DateTime diaYHoraActual)
        {
            TimeSpan tiempoActual = diaYHoraActual.TimeOfDay;
            int horaActual = tiempoActual.Hours;
            int minutoActual = tiempoActual.Minutes;
            int diaActual = (int)DateTime.Now.DayOfWeek;

            TimeSpan tiempoNotificacion = diaNot.Hora;
            int horaNotificacion = tiempoNotificacion.Hours;
            int minutoNotificacion = tiempoNotificacion.Minutes;

            bool esElDia = ((int)diaNot.Dia == diaActual);
            bool esLaHora = (horaActual == horaNotificacion);
            bool esElMinuto = (minutoActual == minutoNotificacion);

            return (esElDia && esLaHora && esElMinuto);
        }
    }
}