using System.Collections.Generic;

namespace Library
{
    public class Bitacora: IObservable
    {
        protected IList<IObservador> observadores = new List<IObservador>();

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