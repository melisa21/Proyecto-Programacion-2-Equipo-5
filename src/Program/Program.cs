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


            //DateTime fecha = programaEmisor.UsuariosDelPrograma[1].BitacoraUsuario.CorrerFechaALunes(DateTime.Today);
            //int posicion = programaEmisor.UsuariosDelPrograma[1].BitacoraUsuario.BuscarBitacoraSemanalPorFecha(fecha);
            //Console.WriteLine(posicion);


            //ComunicadorTelegram.MainTelegram();
            //ComunicadorConsola.MainConsola();

            persistor.GuardarUsuarios(programaEmisor.UsuariosDelPrograma);
        }
    }
}
