using System;

namespace Library
{
    public class ReflexionMetacognitiva : Entrada
    {
        /// <summary>
        /// Por SRP, ReflexionMetacognitiva tiene la responsabilidad
        ///  sobre las funcionalidades de las Entradas como ReflexionMetacognitiva
        /// Es importante tener en cuenta esto dado que es importante
        ///  distinguir que esta entrada debe ser comletada despues de la semana
        /// </summary>
        
        public ReflexionMetacognitiva ( Mensaje msg): base(msg)
        {

        }
        
    }
}