/***************************************
Se aplica patron State
******************************************/

namespace Library
{
    public abstract class EstadoBitacora
    {
        protected Bitacora bitacora;

        public EstadoBitacora(Bitacora bitacora)
        {
            this.bitacora = bitacora;
        }

        public abstract void AgregaBitacoraSemanal(BitacoraSemanal bitacoraSemanal);
        public abstract void Borra();
        public abstract void SuprimeBitacoraSemanal(BitacoraSemanal bitacoraSemanal);
        public abstract EstadoBitacora EstadoSiguiente();

    }
}