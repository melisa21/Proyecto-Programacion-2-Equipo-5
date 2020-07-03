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
        public ConfiguracionNotificacion():base(){}
        public ConfiguracionNotificacion(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario)
        {
            
        }

   }
}
