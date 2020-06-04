using System;

namespace Library
{
    public class ReflexionSemanal : Entrada
    {
        
        /// <summary>
        /// Por SRP, ReflexionSemanal tiene la responsabilidad
        ///  sobre las funcionalidades de las Entradas como ReflexionSemanal
        /// Es importante tener en cuenta esto dado que es importante
        ///  distinguir que esta entrada debe ser comletada despues de la semana
        /// </summary>
        

        public ReflexionSemanal (Mensaje msg): base(msg)
        {

        }
        
    }
}