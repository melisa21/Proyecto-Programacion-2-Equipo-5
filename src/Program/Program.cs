using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SolicitudNotificacion solicitud = new SolicitudNotificacion();
            ComunicadorTelegram.MainTelegram();
            //ComunicadorConsola.MainConsola();

            //Configuracion.MenuInicial();

            
            /*Usuario usuario = Usuario.GetUsuario();
            if (usuario.modo == Usuario.ModoDeUso.Telegram)
                ComunicadorTelegram.MainTelegram();*/
        }
    }
}
