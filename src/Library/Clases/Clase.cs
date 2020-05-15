/*
Clase: Representa una dia de clase con su fecha y horario.
DateTime: https://docs.microsoft.com/en-us/dotnet/api/system.datetime
TimeSpan: https://docs.microsoft.com/en-us/dotnet/api/system.timespan
*/
using System;

namespace Library
{
    public class Clase
    {
        public DateTime Dia {get; set;}
        
        public TimeSpan horarioInicio {get; set;}

        public TimeSpan horarioFin {get; set;}
    }
}