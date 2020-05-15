/***************************************
Se aplica patron State
******************************************/

namespace Library
{
    public abstract class EstadoBitacoraSemanal
    {
        protected BitacoraSemanal bitacoraSemanal;

        public EstadoBitacoraSemanal(BitacoraSemanal bitacoraSemanal)
        {
            this.bitacoraSemanal = bitacoraSemanal;
        }

        public abstract void AgregaEntrada(IEntrada entrada);
        public abstract void Borra();
        public abstract void SuprimeEntrada(IEntrada entrada);
        public abstract EstadoBitacoraSemanal EstadoSiguiente();

    }
}