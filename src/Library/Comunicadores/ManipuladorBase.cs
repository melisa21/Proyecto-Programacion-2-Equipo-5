using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public abstract class ManipuladorBase: IManipulador
    {
        public long IDUsuario{get;set;}
        public TipoEntrada Entrada{get; set;}

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MensajeEntrada{get;set;}

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Respuesta{get;set;}
        private IManipulador siguiente = null;

        public ManipuladorBase()
        {}
        
        public ManipuladorBase(string mensajeEntrada, long iDUsuario)
        {
            this.MensajeEntrada=mensajeEntrada;
            this.IDUsuario= iDUsuario;
            
        }  

        public void CambiarSiguiente(IManipulador m)
        {
            
            this.siguiente = m;
            //Manipular();
            
        }

        public virtual void Manipular()
        {   
            
            if (siguiente!= null)
            {
                siguiente.Manipular();
            }
           
            
        }
    }
}