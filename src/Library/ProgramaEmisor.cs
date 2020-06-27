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
    public class ProgramaEmisor
    {
        
        
        private static ProgramaEmisor instancia = null;

        private List<Usuario> usuariosDelPrograma = null;

        List<Usuario> UsuariosDelPrograma{get; set;}


        /// <summary>
        /// ProgramaEmisor en el encargado de comunicarse con el usuario a traves del comunicador.
        /// </summary>
        /// <param name="name">Nombre del objeto</param>
        private ProgramaEmisor()
        {
            
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


        

    }
}