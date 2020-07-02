using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuracion configuracion = Configuracion.GetConfiguracion();
            configuracion.Comienzo();

            //PersistorUsuarios persistor = PersistorUsuarios.GetPersistorUsuarios();
            //ProgramaEmisor programaEmisor = ProgramaEmisor.GetInstancia();

            //programaEmisor.UsuariosDelPrograma = persistor.CargarUsuarios();

            //ComunicadorTelegram.MainTelegram();
            //ComunicadorConsola.MainConsola();
/*
            Configuracion.MenuInicial();

            Usuario usuario = Usuario.GetUsuario();
            if (usuario.modo == Usuario.ModoDeUso.Telegram)
                ComunicadorTelegram.MainTelegram();
  */
        }
    }
}
