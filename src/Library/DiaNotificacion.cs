using System;

namespace Library
{
    public class DiaNotificacion
        {
            public DiaNotificacion(Dias dia)
            {
                this.Dia = dia;
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