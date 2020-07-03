
namespace Library
{
    //Esta interfaz es la que sugiere el patron Cadena de Responsabilidades
    /* Este patron permite pasar solicitudes a lo largo de una cadena de controladores. 
    Al recibir una solicitud, cada controlador decide procesar la solicitud o
    pasarla al siguiente controlador de la cadena.
    La clase ControladoraDialogo hace uso de esto para saber cual responsabilidad atender*/
    public interface IManipulador
    {
        string Respuesta{get; set;}
        void CambiarSiguiente(IManipulador m);
        void Manipular();
    }
}
