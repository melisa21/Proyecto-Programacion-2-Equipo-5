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
            programaEmisor.UsuariosDelPrograma = persistor.CargarUsuarios();


            //ComunicadorTelegram.MainTelegram();
            //ComunicadorConsola.MainConsola();

        }
    }
}
