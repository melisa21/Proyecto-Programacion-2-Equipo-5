namespace Library
{
    public interface IObservable
    {
        void Agrega(IObservador observador);

        void Elimina(IObservador observador);

        void Notifica();
    }
}