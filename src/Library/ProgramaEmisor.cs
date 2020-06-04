using System;

namespace Library
{
    public class ProgramaEmisor
    {
        /// <summary>
        /// EsTA clase debe seguir SINGLETON dado que permite asegurarse de que ProgramaEmisor
        /// tenga solo una instancia. Además no necesitamos
        ///  mas de una instancia esto generaria un conflicto
        /// Ademas, teniendo en cuanta EXPERT, esta tiene la informacion
        ///  necesaria para crear las bitacora que se necesita la cual tambien es singleton
        /// Adicionalmente, en base a CREATOR esta debe ser la responsable de crear
        ///  las instancias de la clase Bitacora
        /// De este se crea en configuracion
        /// </summary>
        
        
        private static ProgramaEmisor instancia = null;

        protected Bitacora bitacora = null;


        public Bitacora Bitacora
        {
            get
            {
                return bitacora;
            }
        }

        /// <summary>
        /// ProgramaEmisor en el encargado de comunicarse con el usuario a traves del comunicador.
        /// </summary>
        /// <param name="name">Nombre del objeto</param>
        public ProgramaEmisor()
        {
            this.bitacora = new Bitacora();
        }

        public static ProgramaEmisor GetInstancia()
        {
            if (instancia == null)
                instancia = new ProgramaEmisor();
            return instancia;
        }

        public void CrearMensaje()
        {

        }

        public void EnviarMensaje()
        {

        }
        public void RecibirMensaje()
        {

        }

        /// <summary>
        /// Delega a la Bitacora con la correspondiente fecha la posibilidad
        /// de guardar el Mensaje como contenido de la entrada.
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        /// <param name="tipoEntrada">"objetivo" "planificaciondiaria" "reflexionsemanal" "reflexionmetacognitiva"</param>
        /// <param name="fecha">fecha de la bitacora semanal a a la que se quiere guardar la entrada</param>
        public void GuardarEnBitacora(Mensaje msg, string tipoEntrada, DateTime fecha)
        {
            this.Bitacora.GuardarMensajeEnEntrada(msg,tipoEntrada, fecha);
        }

    }
}