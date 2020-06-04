using System;
using System.Collections.Generic;

namespace Library
{
    public class Bitacora
    {

        private static Bitacora instancia = null;

        protected List<BitacoraSemanal> bitacoraSemanals = null;
        
        
        public List<BitacoraSemanal> BitacoraSemanals
        {
            get
            {
                return bitacoraSemanals;
            }
        }
      
        public DateTime FechaFinDeCurso{get; set;}

        public Bitacora()
        {
            this.bitacoraSemanals = new List<BitacoraSemanal>();
        }

        public static Bitacora GetInstancia()
        {
            if (instancia == null)
                instancia = new Bitacora();
            return instancia;
        }

        public DateTime CorrerFechaALunes(DateTime fechaHoy)
        {
            DateTime fechaBitacoraSemanalInicial=fechaHoy;
            if (fechaHoy.DayOfWeek == DayOfWeek.Tuesday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(6);
            if (fechaHoy.DayOfWeek == DayOfWeek.Wednesday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(5);
            if (fechaHoy.DayOfWeek == DayOfWeek.Thursday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(4);
            if (fechaHoy.DayOfWeek == DayOfWeek.Friday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(3);
            if (fechaHoy.DayOfWeek == DayOfWeek.Saturday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(2);
            if (fechaBitacoraSemanalInicial.DayOfWeek == DayOfWeek.Sunday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(1);
            return fechaBitacoraSemanalInicial;
        }
        public void CrearBitacoraSemanal()
        {
            BitacoraSemanal bitacoraSemanal;
            DateTime fechaFin=this.FechaFinDeCurso.Date;
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaBitacoraSemanalInicial=CorrerFechaALunes(fechaHoy);
            
            for (DateTime fechaBitacoraSemanal=fechaBitacoraSemanalInicial;
                fechaBitacoraSemanal.CompareTo(fechaFin)<=0;
                fechaBitacoraSemanal=fechaBitacoraSemanal.AddDays(7))
                bitacoraSemanal = new BitacoraSemanal(fechaBitacoraSemanal);
        }

        public int BuscarBitacoraSemanalPorFecha(DateTime fechaBuscada)
        {
            int indice=-1;
            foreach (BitacoraSemanal b in bitacoraSemanals)
            {
                if (b.Fecha.Date.Equals(fechaBuscada.Date))
                    indice = bitacoraSemanals.IndexOf(b);
            }        
            return indice;
        }

         public void GuardarMensajeEnEntrada(Mensaje msg, string tipoEntrada, DateTime fecha )
        {
            //buscar biracora semenal con fecha 
            int indice = BuscarBitacoraSemanalPorFecha(fecha);
            //guardarmensaje en la encontrada
            this.BitacoraSemanals[indice].GuardarMensajeEnEntrada(msg,tipoEntrada);
        }
    }
}