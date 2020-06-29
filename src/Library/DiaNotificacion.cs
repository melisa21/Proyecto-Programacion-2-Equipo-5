using System;

namespace Library
{
    public class DiaNotificacion
    {
        public DiaNotificacion(TipoEntrada tipo, Dia dia, TimeSpan hora)
        {
            this.Tipo = tipo;
            this.Dia = dia;
            this.Hora = hora;
        }
        public TipoEntrada Tipo {get; set;}
        public Dia Dia {get; set;}
        public TimeSpan Hora {get; set;}
        public String TipoDeEntradaANotificar()
        {
            switch ((int)this.Tipo)
            {
                case 0:
                    return "Objetivo";
                case 1:
                    return "Planificación diaria";
                case 2:
                    return "Reflexión semanal";
                case 3:
                    return "Reflexión metacognitiva";
                default:
                    return null;
            }
        }

    }
}