using System;
using System.Collections.Generic;
/*********************************
BitacoraSeamanal tiene estados posibles "vacia" "terminada"
********************************/

namespace Library
{
        /// <summary>
        /// Por SRP, BitacoraSemanal tiene la responsabilidad
        ///  sobre las funcionalidades de las misma
        /// Teniendo en cuenta Expert, esta clase tiene la responsabilidad
        ///  dado que es el experto en la fecha a ala cual corresponde esta y su estado
        /// cumpliendo la responsabilidad de manipular esta informacion
        /// Ademas tiene la informacion necesaria para guardar el mensaje en las entradas segun cual sea el caso
        /// </summary>
        public class BitacoraSemanal
        {
        


        protected List<Entrada> listObjetivo= new List<Entrada>();
        protected List<Entrada> listPlanificacionDiaria = new List<Entrada>();
        protected List<Entrada> listReflexionSemanal = new List<Entrada>();
        protected List<Entrada> listReflexionMetacognitiva = new List<Entrada>();

        protected IEscribir escribir ;
        
        
        public List<Entrada> ListObjetivo { get; set; }
  
        public List<Entrada> ListPlanificacionDiaria { get; set; }

        public List<Entrada> ListReflexionSemanal { get; set; }

        public List<Entrada> ListReflexionMetacognitiva { get; set; }
        
        public IEscribir Escribir{get; set;}

        

        //****************************************
        public DateTime Fecha { get; set; }

        //Los estados definidos "vacia" "finalizada" 
        public TipoEstado Estado { get; set; }
        //****************************************

        


        /// <summary>
        /// Bitacora con coleccion de las entradas correspondientes a cada categoria.
        /// </summary>
        /// <param name="fecha">Fecha correspondiente a la semana
        ///  de la Bitacora, el comeinzo de la semana</param>
        /// <param name="name">Nombre del objeto</param>
        public BitacoraSemanal(DateTime fecha)
        {
            this.Estado = TipoEstado.Vacia;
            this.Fecha = fecha;
            
        }


        /// <summary>
        /// Cambia el estado de la Bitacora Semanal.
        /// </summary>
        public void EstadoSiguiente()
        {
            if (this.Estado == TipoEstado.Vacia)
                this.Estado = TipoEstado.Finalizada;
            
        }

        /// <summary>
        /// Guarda el mensaje dentro de la lista de objetivos
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        public void GuardarObjetivo(Mensaje msg)
        {
                Entrada eObjetivo = new Entrada(msg);
                ListObjetivo.Add(eObjetivo);
        }

        
        /// <summary>
        /// Guarda el mensaje dentro de la lista de planificaciones diarias
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        public void GuardarPlanificacionDiaria(Mensaje msg)
        {
                Entrada ePlanificacionDiaria = new Entrada(msg);
                ListPlanificacionDiaria.Add(ePlanificacionDiaria);
        }

        
        /// <summary>
        /// Guarda en mensaje dentro de la lista de reflexiones semanales
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        public void GuardarReflexionSemanal(Mensaje msg)
        {
                Entrada eReflexionSemanal = new Entrada(msg);
                ListReflexionSemanal.Add(eReflexionSemanal);
        }


        
        /// <summary>
        /// Guarda en mensaje dentro de la lista de reflexiones metacognitivas
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        public void GuardarReflexionMetacognitiva(Mensaje msg)
        {       
                Entrada eReflexionMetacognitiva = new Entrada(msg);
                ListReflexionMetacognitiva.Add(eReflexionMetacognitiva);

        }


        /// <summary>
        /// Segun lo que eligió el usuario de como se quiere mostrar sus entradas,
        ///  se crean la instancia segun corresponda para delegar la repsonsabilidad que a ellas mismas compete.
        /// </summary>
        /// <param name="tipoEscritura">Tipo de Escritura elegida por el usuario: "consola" "word" "markdown"</param>
        public void CrearEscritura(TipoEscritura tipoEscritura)
        {
                if (Estado == TipoEstado.Finalizada)
                {
                    if (tipoEscritura == TipoEscritura.Word)
                    {
                        this.Escribir = new Word();
                    }
                    if (tipoEscritura == TipoEscritura.Markdown)
                    {
                            this.Escribir = new Markdown();
                    }
                    Escribir.Escribir();
                }
        }

       
    }
}