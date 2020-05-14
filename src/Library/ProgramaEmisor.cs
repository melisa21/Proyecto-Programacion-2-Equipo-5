namespace Library
{
    public class ProgramaEmisor: IPrograma, IObservador
    {
        private Bitacora bitacora;
        



        public ProgramaEmisor(Bitacora bitacora)
        {
            this.bitacora = bitacora;
            bitacora.Agrega(this);
        }

        public void Actualiza()
        {

        }
    }
}