/*******************************************************************************
Interfaz usada para aplicar patron Observer
Bitacora, BitacoraSemanal y Clases la implementan
********************************************************************************/
namespace Library
{
    public interface IObservable
    {
        void Agrega(IObservador observador);

        void Elimina(IObservador observador);

        void Notifica();
    }
}