using System.Collections.Generic;
/*********************************
BitacoraSemanal esta involucrada en los patrones Observer y State
Por un lado, Bitacora Observa a esta
Por otro lado, BitacoraSeamanal tiene tres estados posibles Entregada, NoRealizada y EnCurso 
********************************/

namespace Library
{
    public class BitacoraSemanal: IObservable
    {
        private IList<IObservador> observadores = new List<IObservador>();

        protected IEntrada objetivo;
        protected IEntrada planificacionDiaria;
        protected IEntrada reflexionSemanal;
        protected IEntrada reflexionMetacognitiva;
        
        protected EstadoBitacoraSemanal estadoBitacoraSemanal;

        public IEntrada Objetivo { get; set; }
  
        public IEntrada PlanificacionDiaria { get; set; }

        public IEntrada ReflexionSemanal { get; set; }

        public IEntrada ReflexionMetacognitiva { get; set; }
        public BitacoraSemanal()
        {
            estadoBitacoraSemanal = new BitacoraSemanalNoRealizada(this);
        }

        public void AgregaBitacoraSemanal(IEntrada entrada)
        {
            estadoBitacoraSemanal.AgregaEntrada(entrada);
        }

        public void SuprimeBitacoraSemanal(IEntrada entrada)
        {
            estadoBitacoraSemanal.SuprimeEntrada(entrada);
        }

        public void Borra()
        {
            estadoBitacoraSemanal.Borra();
        }

        public void EstadoSiguiente()
        {
            estadoBitacoraSemanal = estadoBitacoraSemanal.EstadoSiguiente();
        }




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
    }
}