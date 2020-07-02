using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class Comienzo: ManipuladorBase
    {
        public Comienzo(string mensajeEntrada, int iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            
            switch(MensajeEntrada)
            {
                case "/start": 
                    Respuesta = "¡Bienvenido!\n ¿Qué quieres hacer?\n"+
                    " * SI QUIERES ESCRIBIR TU BITÁCORA ESCRIBE: escribir \n"+
                    " * SI QUIERES CONFIGURAR EL MOMENTO DE NOTIFICACIÓN DE LAS ENTRADAS ESCRIBE: configurar\n"+
                    " * SI QUIERES SALIR DEL BOT ESCRIBE: salir \n"+
                    "___";
                    
                    break;

                default:
                    Respuesta = "No se puede comenzar";
                    base.Manipular();
                    break;
            }

            
        }
    }
}