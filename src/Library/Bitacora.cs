using System;
using System.Collections.Generic;

namespace Library
{
    public class Bitacora: IObservable
    {
        private static Bitacora instancia = null;

        private IList<IObservador> observadores = null;

        protected IList<BitacoraSemanal> bitacoraSemanals = null;
        

    
        public IList<BitacoraSemanal> BitacoraSemanals
        {
            get
            {
                return bitacoraSemanals;
            }
        }
      

        public Bitacora()
        {
            this.observadores = new List<IObservador>();
            this.bitacoraSemanals = new List<BitacoraSemanal>();
        }

        public static Bitacora getInstancia()
        {
            if (instancia == null)
                instancia = new Bitacora();
            return instancia;
        }

        public void Agrega(IObservador observador)
        {
            observadores.Add(observador);
        }

        public void Elimina(IObservador observador)
        {
            observadores.Remove(observador);
        }

        public void Notifica()
        {
            foreach (IObservador observador in observadores)
                observador.Actualiza();
        }

         public void GuardarMensajeEnEntrada(Mensaje msg, string tipoEntrada, DateTime fecha )
        {
            BitacoraSemanal bitacoraSemanal = new BitacoraSemanal(fecha);
            bitacoraSemanal.GuardarMensajeEnEntrada(msg,tipoEntrada);
            bitacoraSemanals.Add(bitacoraSemanal);
        }
    }
}