using System;

namespace Library
{
    public class BitacoraEntregada: EstadoBitacora
    {
        public BitacoraEntregada(Bitacora bitacora) : base(bitacora)
        {
        }

        public override void AgregaBitacoraSemanal(BitacoraSemanal bitacorasemanal) { }

        public override void Borra() { }

        public override void SuprimeBitacoraSemanal(BitacoraSemanal bitacorasemanal) { }

        public override EstadoBitacora EstadoSiguiente()
        {
            return this;
        }

    }
}
