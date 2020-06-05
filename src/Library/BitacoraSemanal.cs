using System;
using System.Collections.Generic;
/*********************************
BitacoraSeamanal tiene tres estados posibles "vacia" "encurso" "terminada"
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


        protected IList<Objetivo> listObjetivo= new List<Objetivo>();
        protected IList<PlanificacionDiaria> listPlanificacionDiaria = new List<PlanificacionDiaria>();
        protected IList<ReflexionSemanal> listReflexionSemanal = new List<ReflexionSemanal>();
        protected IList<ReflexionMetacognitiva> listReflexionMetacognitiva = new List<ReflexionMetacognitiva>();

        protected IEscribir escribir ;
        
        
        public IList<Entrada> ListObjetivo { get; set; }
  
        public IList<Entrada> ListPlanificacionDiaria { get; set; }

        public IList<Entrada> ListReflexionSemanal { get; set; }

        public IList<Entrada> ListReflexionMetacognitiva { get; set; }
        
        public IEscribir Escribir{get; set;}

        

        //****************************************
        public DateTime Fecha { get; set; }

        //Los estados definidos "vacia" "encurso" "terminada" 
        public string Estado { get; set; }
        //****************************************



        /// <summary>
        /// Bitacora con coleccion de las entradas correspondientes a cada categoria.
        /// </summary>
        /// <param name="fecha">Fecha correspondiente a la semana
        ///  de la Bitacora, el comeinzo de la semana</param>
        /// <param name="name">Nombre del objeto</param>
        public BitacoraSemanal(DateTime fecha)
        {
            this.Estado = "vacio";
            this.Fecha = fecha;
            
        }


        /// <summary>
        /// Cambia el estado de la Bitacora Semanal.
        /// </summary>
        public void EstadoSiguiente()
        {
            if (this.Estado == "vacio")
                this.Estado = "encurso";
            else if (this.Estado == "encurso")
                this.Estado = "terminada";
            
        }

        /// <summary>
        /// Guardar el Mensaje como contenido de la entrada segun el tipo de entrada y la crea.
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        /// <param name="tipoEntrada">"objetivo" "planificaciondiaria" "reflexionsemanal" "reflexionmetacognitiva"</param>
        public void GuardarMensajeEnEntrada(Mensaje msg, string tipoEntrada)
        {
            if (tipoEntrada == "objetivo")
            {
                Entrada eObjetivo = new Objetivo(msg);
                ListObjetivo.Add(eObjetivo);
            }

            if (tipoEntrada == "planificaciondiaria")
            {
                Entrada ePlanificacionDiaria = new PlanificacionDiaria(msg);
                ListPlanificacionDiaria.Add(ePlanificacionDiaria);
            }

            if (tipoEntrada == "reflexionsemanal" )
            {
                Entrada eReflexionSemanal = new ReflexionSemanal(msg);
                ListReflexionSemanal.Add(eReflexionSemanal);
            }

            if (tipoEntrada == "reflexionmetacognitiva")
            {
                Entrada eReflexionMetacognitiva = new ReflexionMetacognitiva(msg);
                ListReflexionMetacognitiva.Add(eReflexionMetacognitiva);
            }

            this.EstadoSiguiente();

        }



        /// <summary>
        /// Segun lo que eligió el usuario de como se quiere mostrar sus entradas,
        ///  se crean la instancia segun corresponda para delegar la repsonsabilidad que a ellas mismas compete.
        /// </summary>
        /// <param name="tipoEscritura">Tipo de Escritura elegida por el usuario: "consola" "word" "markdown"</param>
        public void CrearEscritura(string tipoEscritura)
        {
                if (Estado == "terminada")
                {
                    if (tipoEscritura == "consola")
                    {
                        this.Escribir = new ComunicadorConsola();
                        
                    }
                    if (tipoEscritura == "word")
                    {
                        this.Escribir = new Word();
                    }
                    if (tipoEscritura == "markdown")
                    {
                            this.Escribir = new Markdown();
                    }
                    Escribir.Escribir();
                }
        }

       
    }
}