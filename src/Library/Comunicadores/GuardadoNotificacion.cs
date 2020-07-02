using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class GuardadoNotificacion: ConfiguracionNotificacion
    {
        public GuardadoNotificacion():base(){}
        
        public GuardadoNotificacion(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
                
                //Guardo Dia Notificacion en logica
                
                ProgramaEmisor p = ProgramaEmisor.GetInstancia();
                int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario==EstadoDialogo.GuardadoNotificacion)
            {
                p.GuardarHoraDiaNotificacionAUsuario(TimeSpan.Parse(MensajeEntrada),IDUsuario);
                Respuesta = "Guardado tu dia de notificacion\n Escribe algo para continuar";
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario=EstadoDialogo.Comienzo;
            }
            else
            {
                Respuesta ="Fin guardado";
                base.Manipular();
            }
                
            
            
        }
    }
}