using System;

namespace Library
{
    [Serializable]
    public class DiaNotificacion
    {

        public DiaNotificacion(){}

        public DiaNotificacion(TipoEntrada tipo, Dias dia, TimeSpan hora)
        {
            this.Tipo = tipo;
            this.Dia = dia;
            this.Hora = hora;
        }

        public TipoEntrada Tipo { get; set; }
        public Dias Dia { get; set; }
        public TimeSpan Hora { get; set; }

        public override string ToString()
        {
            return $"{this.Tipo.ToString()},{this.Dia.ToString()},{this.Hora.ToString()}";
        }
    }
}