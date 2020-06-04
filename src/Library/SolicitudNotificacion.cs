using System.Collections.Generic;
using System.Timers;
using System;
namespace Library
{
    public class SolicitudNotificacion
    {
        private static List<Entrada> entradas;
        public Timer aTimer {get; set;}

        public SolicitudNotificacion(List<Entrada> data){
            entradas = data;
        }
        public void crearSolicitud()
        {
            
            if(entradas.Count == 0){return;}
            // Seteamos el timer con el evento
            aTimer = new Timer(1000);
            aTimer.Elapsed += VerificarHoraYNotificar;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void VerificarHoraYNotificar(Object source, ElapsedEventArgs e)
        {
            foreach (Entrada entrada in entradas)
            {
                if(esMomentoDeNotificar(entrada, DateTime.Now))
                {
                    Console.WriteLine("Es Hora De Trabajar en la Bitacora!");
                }
            }
        }

        public static bool esMomentoDeNotificar(Entrada entrada, DateTime diaYHoraActual)
        {
            TimeSpan tiempoActual = diaYHoraActual.TimeOfDay;
            int horaActual = tiempoActual.Hours;
            int minutoActual = tiempoActual.Minutes;
            int diaActual = (int)DateTime.Now.DayOfWeek;

            TimeSpan tiempoNotificacion = entrada.HoraDeNotificacion;
            int horaNotificacion = tiempoNotificacion.Hours;
            int minutoNotificacion = tiempoNotificacion.Minutes;

            bool esElDia = (entrada.DiaDeNotificacion == diaActual);
            bool esLaHora = (horaActual == horaNotificacion);
            bool esElMinuto = (minutoActual == minutoNotificacion);

            return (esElDia && esLaHora && esElMinuto);
        }
    }
}