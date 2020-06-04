//Configuracion servira para dejar el bot pronto para funcionar la primera vez que el usuario la utilize.
using System;
using System.Collections.Generic;

namespace Library
{
    public static class Configuracion
    {
        public static void Menu()
        {
            Usuario usuario = Usuario.GetUsuario();
            CambiarNombreUsuario(usuario);
            EstablecerPlataforma(usuario);
            EstablecerDias(usuario);

        }

        private static void CambiarNombreUsuario(Usuario usuario)
        {
            Console.WriteLine("Ingrese un nombre: ");
            while (true)
            {
                try
                {
                    string nombre = Console.ReadLine();
                    Usuario.ValidarNombre(nombre);
                    usuario.Nombre = nombre;
                    break;
                }
                catch (NombreVacioException)
                {
                    Console.WriteLine("El nombre no puede quedar vacio. Ingrese un nombre: ");
                }
            }

        }
        public static void EstablecerPlataforma(Usuario usuario)
        {

            while (true)
            {
                Console.WriteLine("Utilizar el bot desde Telegram (1) o la Consola (0)?");
                string respuesta = Console.ReadLine();
                if (respuesta == "1" || respuesta.ToLower() == "telegram")
                {
                    usuario.modo = Usuario.ModoDeUso.Telegram;
                    break;
                }
                else if (respuesta == "0" || respuesta.ToLower() == "consola")
                {
                    usuario.modo = Usuario.ModoDeUso.Consola;
                    break;
                }
            }
        }

        private static void EstablecerDias(Usuario usuario)
        {
            Console.WriteLine("\nAhora eligira cuando comenzar a ser notificado de cada tipo de entrada");
            string textoDias = "Ninguno, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo";
            Console.WriteLine(textoDias);

            string textoObjetivos = "\nQue dia quiere que empieze a ser notificado de hacer los Objetivos?";
            string textoPlanificacion = "\nY de la Planificacion?";
            string textoSemanal = "\nDe la Reflexion Semanal?";
            string textoMetacogniva = "\nY de la Reflexion Metacognitiva?";
            List<string> textosEntradas = new List<string> { textoObjetivos, textoPlanificacion, textoSemanal, textoMetacogniva };

            List<DiaNotificacion.Dias> dias = new List<DiaNotificacion.Dias>();
            for (int i = 0; i < usuario.diasNotificacion.Count; i++)
            {
                Console.WriteLine(textosEntradas[i]);
                while (true)
                {
                    try
                    {
                        string respuesta = Console.ReadLine();
                        DiaNotificacion.Dias dia = (DiaNotificacion.Dias)Enum.Parse(typeof(DiaNotificacion.Dias), respuesta, true);
                        break;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Dia invalido, intente nuevamente: ");
                    }
                }

                Console.WriteLine("Desde que hora? (XX:XX)");
                while (true)
                {
                    try
                    {
                        string respuesta = Console.ReadLine();
                        TimeSpan hora = TimeSpan.Parse(respuesta);
                        if (hora < TimeSpan.Zero || hora > TimeSpan.FromDays(1))
                        {
                            throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Formato invalido: Sobran digitos.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato invalido: Tiene que ser del tipo XX:XX.");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Hora invalida: No puede ser mas grande que un dia ni ser negativa.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Lo que sea que hayas hecho no funciona.");
                    }
                }


            }
        }
    }
}