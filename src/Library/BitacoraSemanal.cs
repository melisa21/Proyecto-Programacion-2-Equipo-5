using System;
using System.Collections.Generic;
/*********************************
BitacoraSeamanal tiene estados posibles "vacia" "terminada"
********************************/

namespace Library
{
    public class BitacoraSemanal
    {
        /// <summary>
        /// Por SRP, BitacoraSemanal tiene la responsabilidad
        ///  sobre las funcionalidades de las misma
        /// Teniendo en cuenta Expert, esta clase tiene la responsabilidad
        ///  dado que es el experto en la fecha a ala cual corresponde esta y su estado
        /// cumpliendo la responsabilidad de manipular esta informacion
        /// Ademas tiene la informacion necesaria para guardar el mensaje en las entradas segun cual sea el caso
        /// </summary>


        protected List<Objetivo> listObjetivo= new List<Objetivo>();
        protected List<PlanificacionDiaria> listPlanificacionDiaria = new List<PlanificacionDiaria>();
        protected List<ReflexionSemanal> listReflexionSemanal = new List<ReflexionSemanal>();
        protected List<ReflexionMetacognitiva> listReflexionMetacognitiva = new List<ReflexionMetacognitiva>();

        protected IEscribir escribir ;
        
        
        public List<Objetivo> ListObjetivo { get; set; }
  
        public List<PlanificacionDiaria> ListPlanificacionDiaria { get; set; }

        public List<ReflexionSemanal> ListReflexionSemanal { get; set; }

        public List<ReflexionMetacognitiva> ListReflexionMetacognitiva { get; set; }
        
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
        /// Guardar el Mensaje como contenido de la entrada segun el tipo de entrada y la crea.
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        /// <param name="tipoEntrada">"objetivo" "planificaciondiaria" "reflexionsemanal" "reflexionmetacognitiva"</param>
        public void GuardarMensajeEnEntrada(Mensaje msg, TipoEntrada tipoEntrada)
        {
            if (tipoEntrada == TipoEntrada.Objetivo)
            {
                Objetivo eObjetivo = new Objetivo(msg);
                ListObjetivo.Add(eObjetivo);
            }

            if (tipoEntrada == TipoEntrada.PlanificacionDiaria)
            {
                PlanificacionDiaria ePlanificacionDiaria = new PlanificacionDiaria(msg);
                ListPlanificacionDiaria.Add(ePlanificacionDiaria);
            }

            if (tipoEntrada == TipoEntrada.ReflexionSemanal )
            {
                ReflexionSemanal eReflexionSemanal = new ReflexionSemanal(msg);
                ListReflexionSemanal.Add(eReflexionSemanal);
            }

            if (tipoEntrada == TipoEntrada.ReflexionMetacognitiva)
            {
                ReflexionMetacognitiva eReflexionMetacognitiva = new ReflexionMetacognitiva(msg);
                ListReflexionMetacognitiva.Add(eReflexionMetacognitiva);
            }

            this.EstadoSiguiente();

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
                    if (tipoEscritura == TipoEscritura.Consola)
                    {
                        this.Escribir = new ComunicadorConsola();
                        
                    }
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