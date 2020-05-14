namespace Library
{
    internal class BitacoraEnCurso : EstadoBitacora
    {
        public BitacoraEnCurso(Bitacora bitacora) : base(bitacora)
        {
        }

        public override void AgregaBitacoraSemanal(BitacoraSemanal bitacorasemanal) { }

        public override void Borra()
        {
            bitacora.BitacoraSemanals.Clear();
        }

        public override void SuprimeBitacoraSemanal(BitacoraSemanal bitacorasemanal) { }

        public override EstadoBitacora EstadoSiguiente()
        {
            return new BitacoraEntregada(bitacora);
        }
    }
}