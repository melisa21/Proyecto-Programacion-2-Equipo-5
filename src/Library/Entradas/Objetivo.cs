using System;

namespace Library
{
    public class Objetivo : Entrada
    {
        /// <summary>
        /// Por SRP, Objetivo tiene la responsabilidad
        ///  sobre las funcionalidades de las Entradas como Objetivos
        /// Es importante tener en cuenta esto dado que es importante
        ///  distinguir que esta entrada debe ser comletada antes de la semana
        /// </summary>

        public Objetivo (Mensaje msg): base(msg)
        {

        }
        
    }
}