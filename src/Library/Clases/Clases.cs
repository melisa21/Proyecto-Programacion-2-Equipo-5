/***************************************
Considerando Expert Clases es la experta en manejar 
la coleccion correspondiente a Clase,
además contempla un a composición
******************************************/

using System.Collections.Generic;

namespace Library
{
    public class Clases : IClases
    {
        private IList<IObservador> observadores = new List<IObservador>();
        public List<Clase> listClase {get;}
        
        
        public void AgregarClase(Clase clase)
        {
            listClase.Add(clase);
        }
        public void SuprimirClase(Clase clase)
        {
            listClase.Remove(clase);
        }

    
        public void Agrega(IObservador observador) => observadores.Add(observador);
        public void Elimina(IObservador observador) => observadores.Remove(observador);
        public void Notifica()
        {
            foreach (IObservador observador in observadores)
            {
                observador.Actualiza();
            }
        }
    }
}
