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
        public TipoEntrada Entrada{get; set;}

        public Dias Dia{get; set;}

        public TimeSpan Hora{get;set;}

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MensajeEntrada{get;set;}

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Respuesta{get;set;}
        public IManipulador Siguiente{get; set;}

        public ManipuladorBase(string mensajeEntrada)
        {
            this.MensajeEntrada=mensajeEntrada;
            
            Console.WriteLine(MensajeEntrada);
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