using System;
using System.Collections.Generic;
/*********************************
BitacoraSemanal esta involucrada con el patron Observer
Por un lado, Bitacora Observa a esta
Por otro lado, BitacoraSeamanal tiene tres estados posibles "vacia" "encurso" "terminada"
********************************/

namespace Library
{
    public class BitacoraSemanal: IObservable
    {
        protected DateTime date;
        protected string estado;
        //Los estados definidos "vacia" "encurso" "terminada" 


        private IList<IObservador> observadores = new List<IObservador>();

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

        public DateTime Date { get; set; }
        public string Estado { get; set; }

        public BitacoraSemanal(DateTime date)
        {
            Estado = "vacio";
            this.Date = date;
        }

        //Inicio Metodos de IObservable
         public void Agrega(IObservador observador)
        {
            observadores.Add(observador);
        }

        public void Elimina(IObservador observador)
        {
            observadores.Remove(observador);
        }

        public void Notifica()
        {
            foreach (IObservador observador in observadores)
                observador.Actualiza();
        }
        //Fin Metodos de IObservable 

        

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