using System;

namespace Library
{
    public class PlanificacionDiaria : Entrada
    {
        /// <summary>
        /// Por SRP, PlanificacionDiaria tiene la responsabilidad
        ///  sobre las funcionalidades de las Entradas como PlanificacionDiaria
        /// Es importante tener en cuenta esto dado que es importante
        ///  distinguir que esta entrada debe ser comletada antes de la semana
        /// </summary>

        public PlanificacionDiaria (Mensaje msg): base(msg)
        {

        }
        
    }
}