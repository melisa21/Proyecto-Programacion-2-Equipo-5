
namespace Library
{
    public interface IManipulador
    {
        string Respuesta{get; set;}
        void CambiarSiguiente(IManipulador m);
        void Manipular();
    }
}