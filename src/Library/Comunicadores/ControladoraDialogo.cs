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
            

            IManipulador comienzo = new Comienzo(mensajeEntrada,idContacto);
            IManipulador escribirBitacora = new EscribirBitacora(mensajeEntrada,idContacto);
            
            IManipulador eleccionEntrada = new EleccionEntrada(mensajeEntrada,idContacto);
            IManipulador eleccionDia = new EleccionDia(mensajeEntrada,idContacto);
            IManipulador eleccionHora = new EleccionHora(mensajeEntrada,idContacto);
            IManipulador guardadoNotificacion = new GuardadoNotificacion(mensajeEntrada,idContacto);
            

            
            switch(mensajeEntrada)
            {
                case "/start": 
                    if (p.BuscarUsuarioID(idContacto)==-1) //ingreso por priemra vez
                    {
                        response = "Bienvenido!!!\nELIGE LA FECHA QUE FINALIZA LA BITACORA ESCRIBE CON EL SIGUIENTE FORMATO: dd/mm/aaaa \n"+
                                "___";
                    }
                    else
                    {
                        comienzo.Manipular();
                        response = comienzo.Respuesta;
                    }    
                break;

                case "escribir":
                    comienzo.CambiarSiguiente(escribirBitacora);
                    response = escribirBitacora.Respuesta;
                break;

                case "configurar":
                    comienzo.CambiarSiguiente(eleccionEntrada);
                    response = eleccionEntrada.Respuesta;
    
                    
                break;

                case "salir":
                    response = "Chau chau";
                break;

                default:
                    if (p.BuscarUsuarioID(idContacto)==-1) 
                    {
                        
                        IManipulador conf = new ConfigurarFechaFinalizacion(mensajeEntrada,idContacto);
                        conf.Manipular();
                        p.CrearBitacora(idContacto);
                        response = conf.Respuesta;
                    }
                    else
                    {
                        if (mensajeEntrada == "1" || mensajeEntrada == "2" || mensajeEntrada == "3" || mensajeEntrada == "4")
                        {    
                            eleccionEntrada.CambiarSiguiente(eleccionDia);
                            response = eleccionDia.Respuesta;
                            
                        } 
                        else
                        {
                            if ((mensajeEntrada=="lunes") || (mensajeEntrada=="martes") || (mensajeEntrada=="miercoles") ||
                            (mensajeEntrada=="jueves") || (mensajeEntrada=="viernes") || (mensajeEntrada=="sabado") || (mensajeEntrada=="domingo"))
                            {
                                
                                eleccionDia.CambiarSiguiente(eleccionHora);
                                response = eleccionHora.Respuesta;
                            }
                            else
                            {
                                if (mensajeEntrada!="salir")
                                    eleccionHora.CambiarSiguiente(guardadoNotificacion);
                                    response = eleccionHora.Respuesta;   
                            }
                        }
                    }
                break;
            }
            return response;
        } 


    }
}