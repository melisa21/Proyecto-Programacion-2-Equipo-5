namespace Library
{
    internal class BitacoraSemanalEnCurso : EstadoBitacoraSemanal
    {
        public BitacoraSemanalEnCurso(BitacoraSemanal bitacoraSemanal) : base(bitacoraSemanal)
        {
        }

        public override void AgregaEntrada(IEntrada entrada) { }

        public override void Borra()
        {
            
        }

        public override void SuprimeEntrada(IEntrada entrada) { }

        public override EstadoBitacoraSemanal EstadoSiguiente()
        {
            return new BitacoraSemanalEntregada(bitacoraSemanal);
        }
    }
}