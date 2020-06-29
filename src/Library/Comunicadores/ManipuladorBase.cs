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
        public int IDUsuario{get;set;}
        public TipoEntrada Entrada{get; set;}

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MensajeEntrada{get;set;}

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Respuesta{get;set;}
        public IManipulador Siguiente{get; set;}

        public ManipuladorBase(string mensajeEntrada, int iDUsuario)
        {
            this.MensajeEntrada=mensajeEntrada;
            this.IDUsuario= iDUsuario;
            
        }  

        public void CambiarSiguiente(IManipulador m)
        {
            
            this.Siguiente = m;
            Manipular();
            
        }

        public virtual void Manipular()
        {   
            
            if (Siguiente!= null)
            {
                Siguiente.Manipular();
            }
           
            
        }
    }
}