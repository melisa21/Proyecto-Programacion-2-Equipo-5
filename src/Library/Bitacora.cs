using System.Collections.Generic;

namespace Library
{
    public class Bitacora: IObservable
    {
        private IList<IObservador> observadores = new List<IObservador>();

        protected IList<BitacoraSemanal> bitacoraSemanals = new List<BitacoraSemanal>();
        

    
        public IList<BitacoraSemanal> BitacoraSemanals
        {
            get
            {
                return bitacoraSemanals;
            }
        }
      

        public Bitacora()
        {
        
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

         public void GuardarMensajeEnEntrada(Mensaje msg, string tipoEntrada)
        {
            
        }
    }
}