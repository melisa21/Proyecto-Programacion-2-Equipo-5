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

        public ConfiguracionNotificacion(string mensajeEntrada, int iDUsuario):base(mensajeEntrada,iDUsuario)
        {
            
        }

   }
}
