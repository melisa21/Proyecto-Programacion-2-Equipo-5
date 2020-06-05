/*******************************
IComunicador facilitara que el programa funcione sin importar desde donde vengan las entradas de datos.
La implementan las clases Telegram y Consola.
*******************************/

namespace Library
{
    public interface IComunicador
    {
        void EnviarMensaje();
        void RecibirMensaje();
    }
}
