namespace Library
{
    public class ProgramaEmisor: IPrograma, IObservador
    {
        private Bitacora bitacora;
        private EstadoBitacora estadoBitacora;



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