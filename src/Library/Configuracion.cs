using System;
using System.Collections.Generic;


namespace Library
{
    /// <summary>
    /// Configuracion se encarga de establecer que plataforma va a ser usada con el bot.
    /// Es un Singleton ya que queremos que sea un ajuste unico a traves de todo el programa.
    /// </summary>

    public class Configuracion
    {
        private static Configuracion configuracion;

        public ModoDeUso Modo { get; private set; }
        private Configuracion()
        {
        }
        public static Configuracion GetConfiguracion()
        {
            if (configuracion == null)
            {
                configuracion = new Configuracion();
            }
            return configuracion;
        }

        public void Comienzo()
        {
            ConfigurarModo();
        }

        private void ConfigurarModo()
        {
            Console.WriteLine("Escoge el modo de usar el Bot (Telegram, Consola)");
            while (true)
            {
                string respuesta = Console.ReadLine();
                try
                {
                    Modo = (ModoDeUso)Enum.Parse(typeof(ModoDeUso), respuesta, true);
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Modo incorrecto, intente nuevamente.");
                }
            }
            
        }
    }
}