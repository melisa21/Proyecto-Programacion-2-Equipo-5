using System.Collections.Generic;

namespace Library
{
    public class Bitacora: IObservable
    {
        private IList<IObservador> observadores = new List<IObservador>();

        protected IList<BitacoraSemanal> bitacoraSemanals = new List<BitacoraSemanal>();
        
        protected EstadoBitacora estadoBitacora;

    
        public IList<BitacoraSemanal> BitacoraSemanals
        {
            get
            {
                return bitacoraSemanals;
            }
        }
      

        public Bitacora()
        {
            estadoBitacora = new BitacoraNoRealizada(this);
        }

        public void AgregaBitacora(BitacoraSemanal bitacoraSemanal)
        {
            estadoBitacora.AgregaBitacoraSemanal(bitacoraSemanal);
        }

        public void SuprimeBitacora(BitacoraSemanal bitacoraSemanal)
        {
            estadoBitacora.SuprimeBitacoraSemanal(bitacoraSemanal);
        }

        public void Borra()
        {
            estadoBitacora.Borra();
        }

        public void EstadoSiguiente()
        {
            estadoBitacora = estadoBitacora.EstadoSiguiente();
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
    }
}