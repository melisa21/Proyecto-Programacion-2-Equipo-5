using System;
using System.Collections.Generic;


namespace Library
{
    public static class Configuracion
    {
        /// <summary>
        /// Configuracion es una clase estatica que contiene metodos que crea objetos y establece variables con los datos necesarios para el funcionamiento del programa.
        /// Por ahora solo guarda las variables en memoria pero en el futuro podra almacenar y recuperar los datos desde archivos.
        /// </summary>
        public static void MenuInicial()
        {
            Usuario usuario = new Usuario();
            EstablecerNombre(usuario);
            EstablecerPlataforma(usuario);
            EstablecerDias(usuario);

        }

        public static void EstablecerNombre(Usuario usuario)
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

        public static void EstablecerDias(Usuario usuario)
        {
            int cantidadTiposEntrada = 4;
            Dia dia;
            TimeSpan hora;
            List<DiaNotificacion> diasNotificacion = new List<DiaNotificacion>();

            Console.WriteLine("\nEscoja cuando comenzar a ser notificado de cada tipo de entrada");
            string textoDias = "Domingo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado. (Sin Tildes)";

            string textoObjetivos = "\nQue dia quiere que empieze a ser notificado de hacer los Objetivos? \n" + textoDias;
            string textoPlanificacion = "\nY de la Planificacion? \n" + textoDias;
            string textoSemanal = "\nDe la Reflexion Semanal? \n" + textoDias;
            string textoMetacogniva = "\nY de la Reflexion Metacognitiva? \n" + textoDias;
            List<string> textosEntradas = new List<string> { textoObjetivos, textoPlanificacion, textoSemanal, textoMetacogniva };

            List<Dia> dias = new List<Dia>();
            for (int i = 0; i < cantidadTiposEntrada; i++)
            {
                Console.WriteLine(textosEntradas[i]);
                while (true)
                {
                    try
                    {
                        string respuesta = Console.ReadLine();
                        dia = (Dia)Enum.Parse(typeof(Dia), respuesta, true);
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
                TipoEntrada tipo = (TipoEntrada)i;

                diasNotificacion.Add(new DiaNotificacion(tipo,dia, hora));
            }
            usuario.ActualizarDiasDesdeLista(diasNotificacion);
        }
    }
}