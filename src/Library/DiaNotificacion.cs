using System;

namespace Library
{
    public class DiaNotificacion
        {
            public DiaNotificacion(Dias dia, TimeSpan hora)
            {
                this.Dia = dia;
                this.Hora = hora;
            }
            public Dias Dia {get; set;}

            public TimeSpan Hora {get; set;}
            public enum Dias
            {
                Ninguno,
                Lunes,
                Martes,
                Miercoles,
                Jueves,
                Viernes,
                Sabado,
                Domingo
            }


        }
}