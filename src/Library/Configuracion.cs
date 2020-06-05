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
            int cantidadTiposEntrada = 4;
            DiaNotificacion.Dias dia;
            TimeSpan hora;
            List<DiaNotificacion> diasNotificacion = new List<DiaNotificacion>();

            Console.WriteLine("\nEscoja cuando comenzar a ser notificado de cada tipo de entrada");
            string textoDias = "Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado. (Sin Tildes)";

            string textoObjetivos = "\nQue dia quiere que empieze a ser notificado de hacer los Objetivos? \n" + textoDias;
            string textoPlanificacion = "\nY de la Planificacion? \n" + textoDias;
            string textoSemanal = "\nDe la Reflexion Semanal? \n" + textoDias;
            string textoMetacogniva = "\nY de la Reflexion Metacognitiva? \n" + textoDias;
            List<string> textosEntradas = new List<string> { textoObjetivos, textoPlanificacion, textoSemanal, textoMetacogniva };

            List<DiaNotificacion.Dias> dias = new List<DiaNotificacion.Dias>();
            for (int i = 0; i < cantidadTiposEntrada; i++)
            {
                Console.WriteLine(textosEntradas[i]);
                while (true)
                {
                    try
                    {
                        string respuesta = Console.ReadLine();
                        dia = (DiaNotificacion.Dias)Enum.Parse(typeof(DiaNotificacion.Dias), respuesta, true);
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
                        hora = TimeSpan.Parse(respuesta);
                        if (hora < TimeSpan.Zero || hora > TimeSpan.FromDays(1))
                        {
                            throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Formato invalido: Hora fuera de rango.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato invalido: Tiene que ser del tipo XX:XX.");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Formato invalido: Tiene que ser del tipo XX:XX.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Lo que sea que hayas hecho no funciona.");
                    }

                }
                DiaNotificacion.TipoEntrada tipo = (DiaNotificacion.TipoEntrada)i;

                diasNotificacion.Add(new DiaNotificacion(tipo,dia, hora));
            }
            usuario.ActualizarDiasDesdeLista(diasNotificacion);
        }
    }
}