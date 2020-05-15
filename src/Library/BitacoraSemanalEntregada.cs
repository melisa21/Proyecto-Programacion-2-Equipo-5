using System;

namespace Library
{
    public class BitacoraSemanalEntregada: EstadoBitacoraSemanal
    {
        IEscribir escribir;
        
        public BitacoraSemanalEntregada(BitacoraSemanal bitacoraSemanal) : base(bitacoraSemanal)
        {
        }

        public override void AgregaEntrada(IEntrada entrada)  { }

        public override void Borra() { }

        public override void SuprimeEntrada(IEntrada entrada)  { }

        public override EstadoBitacoraSemanal EstadoSiguiente()
        {
            return this;
        }

    }
}
