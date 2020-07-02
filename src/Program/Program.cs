using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuracion configuracion = Configuracion.GetConfiguracion();
            //configuracion.Comienzo();

            PersistorUsuarios persistor = PersistorUsuarios.GetPersistorUsuarios();
            ProgramaEmisor programaEmisor = ProgramaEmisor.GetInstancia();

            List<Usuario> lista = new List<Usuario>();
            Usuario franco = new Usuario();
            franco.Nombre = "Franco";
            franco.IDContacto = 123098;
            lista.Add(franco);

            


            persistor.GuardarUsuarios(lista);

            List<Usuario> listaCargada = persistor.CargarUsuarios();

            foreach (Usuario usuario in listaCargada)
            {
                Console.WriteLine($"{usuario.Nombre} {usuario.IDContacto}");
            }


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
