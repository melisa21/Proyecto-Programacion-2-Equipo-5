using System;

namespace Library
{
    public class DiaNotificacion
        {
            public DiaNotificacion(TipoEntrada tipo, Dias dia, TimeSpan hora)
            {
                this.Tipo = tipo;
                this.Dia = dia;
                this.Hora = hora;
            }

            public TipoEntrada Tipo {get; set;}
            public Dias Dia {get; set;}
            public TimeSpan Hora {get; set;}
            public enum Dias
            {
                Domingo,
                Lunes,
                Martes,
                Miercoles,
                Jueves,
                Viernes,
                Sabado,
            }

            public enum TipoEntrada
            {
                Objetivo,
                Planificacion,
                ReflexionSemanal,
                ReflexionMetacognitiva
            }


        }
}