using System;
using System.Collections.Generic;

namespace Library
{

    /// <summary>
    /// EsTA clase debe seguir SINGLETON dado que permite asegurarse de que ProgramaEmisor
    /// tenga solo una instancia. Además no necesitamos
    ///  mas de una instancia esto generaria un conflicto
    /// Ademas, teniendo en cuanta EXPERT, esta tiene la informacion
    ///  necesaria para crear las bitacora que se necesita la cual tambien es singleton
    /// De este se crea en configuracion
    /// </summary>
    public class ControladoraDialogo
    {
        
        
        private static ControladoraDialogo instancia = null;

        /// <summary>
        /// ProgramaEmisor en el encargado de comunicarse con el usuario a traves del comunicador.
        /// </summary>
        /// <param name="name">Nombre del objeto</param>
        private ControladoraDialogo()
        {
               
        }

        /// <summary>
        /// Metodo propio de haberlo definido segun Singleton.
        /// </summary>
        public static ControladoraDialogo GetInstancia()
        {
            if (instancia == null)
                instancia = new ControladoraDialogo();
            return instancia;
        }

    
        public string GenerarRespuesta(string mensajeEntrada, long idContacto)
        {
            
            string response="Disculpe, no entiendo";

            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            IManipulador conf = new ConfigurarFechaFinalizacion(mensajeEntrada,idContacto);
            IManipulador comienzo = new Comienzo(mensajeEntrada,idContacto);
            IManipulador pideEntrada = new PideEntrada(mensajeEntrada,idContacto);
            IManipulador pideDia = new PideDia(mensajeEntrada,idContacto);
            IManipulador pideHora = new PideHora(mensajeEntrada,idContacto);
            IManipulador guardadoNotificacion = new GuardadoNotificacion(mensajeEntrada,idContacto);
            IManipulador escribirBitacora = new EscribirBitacora(mensajeEntrada,idContacto);
            
            

            comienzo.CambiarSiguiente(conf);

            conf.CambiarSiguiente(pideEntrada);
                
            pideEntrada.CambiarSiguiente(pideDia);
            
            pideDia.CambiarSiguiente(pideHora);

            pideHora.CambiarSiguiente(guardadoNotificacion);

            guardadoNotificacion.CambiarSiguiente(escribirBitacora);

            
            comienzo.Manipular();

            response = comienzo.Respuesta;
            
               
            return response;
        } 


    }
}