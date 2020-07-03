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
            int posUsr =p.BuscarUsuarioID(idContacto);
            
            if (posUsr==-1) //ingreso por primera vez
            {
                Usuario u= new Usuario();
                u.IDContacto = idContacto;
                p.UsuariosDelPrograma.Add(u);
                posUsr = p.BuscarUsuarioID(idContacto);
            }        

            IManipulador comienzo = new Comienzo(mensajeEntrada,idContacto);
            
            IManipulador conf = new ConfigurarFechaFinalizacion(mensajeEntrada,idContacto);
            IManipulador pideFechaNotObjetivo = new PideFechaNotObjetivo(mensajeEntrada,idContacto);
            IManipulador pideDiaNotObjetivo = new PideDiaFechaNotObjetivo(mensajeEntrada,idContacto);
            IManipulador pideHoraNotObjetivo = new PideHoraFechaNotObjetivo(mensajeEntrada,idContacto);
           
            IManipulador pideEntrada = new PideEntrada(mensajeEntrada,idContacto);
            IManipulador pideDia = new PideDia(mensajeEntrada,idContacto);
            IManipulador pideHora = new PideHora(mensajeEntrada,idContacto);
            IManipulador guardadoNotificacion = new GuardadoNotificacion(mensajeEntrada,idContacto);
            
            IManipulador menuComienzo = new MenuComienzo(mensajeEntrada,idContacto);
            IManipulador escribirBitacora = new EscribirBitacora(mensajeEntrada,idContacto);
            IManipulador pideEscribirEntrada = new PideEscribirEntrada(mensajeEntrada,idContacto);
            IManipulador pideEscribirSinFormato = new PideEscribirSinFormato(mensajeEntrada,idContacto);
            IManipulador pidePlanificacionDiaria = new PidePlanificacionDiaria(mensajeEntrada,idContacto);
            
            IManipulador guardarEscribirEntrada = new GuardarEscribirEntrada(mensajeEntrada,idContacto);

            comienzo.CambiarSiguiente(conf);

            conf.CambiarSiguiente(pideFechaNotObjetivo);

            pideFechaNotObjetivo.CambiarSiguiente(pideDiaNotObjetivo);

            pideDiaNotObjetivo.CambiarSiguiente(pideHoraNotObjetivo);
            
            pideHoraNotObjetivo.CambiarSiguiente(guardadoNotificacion);

            
            guardadoNotificacion.CambiarSiguiente(menuComienzo);

            menuComienzo.CambiarSiguiente(escribirBitacora);

            escribirBitacora.CambiarSiguiente(pideEscribirEntrada);

            pideEscribirEntrada.CambiarSiguiente(pideEscribirSinFormato);
            pideEscribirSinFormato.CambiarSiguiente(pidePlanificacionDiaria);
            pidePlanificacionDiaria.CambiarSiguiente(guardarEscribirEntrada);
            comienzo.Manipular();

            Console.WriteLine(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Error==false)
            {
                

                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.Comienzo)
                    response = comienzo.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.Comienzo)
                    response = guardadoNotificacion.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.Comienzo)
                    response = pideEscribirSinFormato.Respuesta;

                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.ConfigurarFechaFinalizacion)
                    response = comienzo.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideFechaNotObjetivo)
                    response = conf.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideDiaFechaNotObjetivo)
                    response = pideFechaNotObjetivo.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideHoraFechaNotObjetivo)
                    response = pideDiaNotObjetivo.Respuesta;                
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.GuardadoNotificacion)
                    response = pideHoraNotObjetivo.Respuesta;

                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.MenuComienzo)
                    response = comienzo.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.EscribirBitacora)
                    response = menuComienzo.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PideEscribirEntrada)
                    response = escribirBitacora.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PideEscribirSinFormato)
                    response = pideEscribirEntrada.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PidePlanificacionDiaria)
                    response = pideEscribirSinFormato.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.GuardarEscribirEntrada)
                    response = pideEscribirSinFormato.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.EscribioEntrada)
                {
                    response = guardarEscribirEntrada.Respuesta;
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.Comienzo;
                }
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.EscribioPlanificacionDiaria)
                {
                    response = pidePlanificacionDiaria.Respuesta;
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.Comienzo;
                }
            }
            else
            {
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideDiaFechaNotObjetivo)
                    response = pideHoraNotObjetivo.Respuesta;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.GuardadoNotificacion)
                    response = guardadoNotificacion.Respuesta;
                
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideEscribirSinFormato)
                    response = pidePlanificacionDiaria.Respuesta;

                
                
                    
            }    
            
            if (response == null)
            {
                response = "Escriba continuar... (C)";
            }    
            return response;
        } 


    }
}