using System;

namespace Library
{
    public class BitacoraNoRealizada: EstadoBitacora
    {
        public BitacoraNoRealizada(Bitacora bitacora): base(bitacora) { }

        public override void AgregaBitacoraSemanal(BitacoraSemanal bitacorasemanal)
        {
            bitacora.BitacoraSemanals.Add(bitacorasemanal);
        }

        public override void Borra()
        {
            bitacora.BitacoraSemanals.Clear();
        }

        public override void SuprimeBitacoraSemanal(BitacoraSemanal bitacorasemanal)
        {
            bitacora.BitacoraSemanals.Remove(bitacorasemanal);
        }

        public override EstadoBitacora EstadoSiguiente()
        {
            return new BitacoraEnCurso(bitacora);
        }


    }
}
