using System;
using System.Collections.Generic;
/*********************************
Por otro lado, BitacoraSeamanal tiene tres estados posibles "vacia" "encurso" "terminada"
********************************/

namespace Library
{
    public class BitacoraSemanal
    {


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


        public DateTime Fecha { get; set; }

        //Los estados definidos "vacia" "encurso" "terminada" 
        public string Estado { get; set; }


        public BitacoraSemanal(DateTime fecha)
        {
            this.Estado = "vacio";
            this.Fecha = fecha;
            
        }


        public void EstadoSiguiente()
        {
            if (this.Estado == "vacio")
                this.Estado = "encurso";
            if (this.Estado == "encurso")
                this.Estado = "terminada";
        }

        //tipoEntrada puede ser: "objetivo" "planificaciondiaria" "reflexionsemanal" "reflexionmetacognitiva"
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