using System;
using System.Collections.Generic;


namespace Library
{
    public class Configuracion
    {
        private static Configuracion configuracion;

        public Formato FormatoObjetivo { get; private set; }
        public Formato FormatoPlanificacion { get; private set; }
        public List<string> ColumnasTablaObjetivo { get; private set; }
        public List<string> ColumnasTablaPlanificacion { get; private set; }
        private Configuracion()
        {
            ColumnasTablaObjetivo = new List<string>();
            ColumnasTablaPlanificacion = new List<string>();
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
            ConfigurarFormato();
        }

        private void ConfigurarFormato()
        {
            Console.WriteLine("Escoge el formato del Objetivo Semanal (SinFormato, Tabla)");
            while (true)
            {
                string respuesta = Console.ReadLine();
                try
                {
                    FormatoObjetivo = (Formato)Enum.Parse(typeof(Formato), respuesta, true);
                    if (FormatoObjetivo == Formato.Tabla)
                    {
                        ConfigurarTabla(ColumnasTablaObjetivo, "Objetivo Semanal");
                    }
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Formato invalido, intente nuevamente.");
                }
            }
            Console.WriteLine("Escoge el formato de la Planificación Diaria (SinFormato, Tabla)");
            while (true)
            {
                string respuesta = Console.ReadLine();
                try
                {
                    FormatoPlanificacion = (Formato)Enum.Parse(typeof(Formato), respuesta, true);
                    if (FormatoPlanificacion == Formato.Tabla)
                    {
                        ConfigurarTabla(ColumnasTablaPlanificacion, "Planificación Diaria");
                    }
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Formato invalido, intente nuevamente.");
                }
            }

        }

        private void ConfigurarTabla(List<string> tabla, string nombre)
        {
            Console.WriteLine($"Escribe la descripción de la primera columna que tendra la tabla de {nombre}:");
            string descripcion = Console.ReadLine();
            tabla.Add(descripcion);

            while (true)
            {
                Console.WriteLine($"LLevas {tabla.Count} columnas. Quieres agregar otra mas? (Si) (No)");
                string respuesta = Console.ReadLine().ToLower();
                if (!(respuesta == "s" || respuesta == "si" || respuesta == "1"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Escribe la descripción:");
                    descripcion = Console.ReadLine();
                    tabla.Add(descripcion);
                }
            }
        }
        
        public enum Formato
        {
            SinFormato,
            Tabla
        }
    }
}