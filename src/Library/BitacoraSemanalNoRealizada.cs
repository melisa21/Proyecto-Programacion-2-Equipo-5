using System;

namespace Library
{
    public class BitacoraSemanalNoRealizada: EstadoBitacoraSemanal
    {
        public BitacoraSemanalNoRealizada(BitacoraSemanal bitacoraSemanal): base(bitacoraSemanal) { }

        public override void AgregaEntrada(IEntrada entrada)
        {
            //bitacoraSemanal.Entradas.Add(entrada);
        }

        public override void Borra()
        {
            //bitacoraSemanal.Entradas.Clear();
        }

        public override void SuprimeEntrada(IEntrada entrada)
        {
            //bitacoraSemanal.Entrada.Remove(entrada);
        }

        public override EstadoBitacoraSemanal EstadoSiguiente()
        {
            return new BitacoraSemanalEnCurso(bitacoraSemanal);
        }


    }
}
