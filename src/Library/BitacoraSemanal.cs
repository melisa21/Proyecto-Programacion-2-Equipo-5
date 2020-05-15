using System.Collections.Generic;

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