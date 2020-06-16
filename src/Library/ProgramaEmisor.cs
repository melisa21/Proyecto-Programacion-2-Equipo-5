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
        private ProgramaEmisor()
        {
            this.bitacora = Bitacora.GetInstancia();
        }

        /// <summary>
        /// Metodo propio de haberlo definido segun Singleton.
        /// </summary>
        public static ProgramaEmisor GetInstancia()
        {
            if (instancia == null)
                instancia = new ProgramaEmisor();
            return instancia;
        }

        /// <summary>
        /// Crea el mensaje.
        /// </summary>
        public void CrearMensaje()
        {

        }

        /// <summary>
        /// Delega a el comunicador el envio del mensaje para el usuario
        /// </summary>
        public void EnviarMensaje()
        {

        }

        /// <summary>
        /// Interpreta el mensaje que envio el mensaje a tarves del comunicador.
        /// </summary>
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
        public void GuardarEnBitacora(Mensaje msg, TipoEntrada tipoEntrada, DateTime fecha)
        {
            this.Bitacora.GuardarMensajeEnEntrada(msg,tipoEntrada, fecha);
            
        }

    }
}