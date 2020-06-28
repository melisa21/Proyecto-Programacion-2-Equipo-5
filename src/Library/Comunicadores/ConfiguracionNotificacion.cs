using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public abstract class ConfiguracionNotificacion: ManipuladorBase
    {

        public DiaNotificacion DiaNot{get;set;}

        
        public ConfiguracionNotificacion(string mensajeEntrada, int iDUsuario,DiaNotificacion diaNot):base(mensajeEntrada,iDUsuario)
        {
            DiaNot = diaNot;
        }

   }
}
