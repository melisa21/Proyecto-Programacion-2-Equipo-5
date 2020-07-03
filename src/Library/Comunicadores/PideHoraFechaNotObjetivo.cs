using System;

namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideHoraFechaNotObjetivo: ConfiguracionNotificacion
    {
        public PideHoraFechaNotObjetivo():base(){}
        
        public PideHoraFechaNotObjetivo(string mensajeEntrada, long iDUsuario):
            base(mensajeEntrada,iDUsuario)
        {}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PideHoraFechaNotObjetivo)
            {
            
                if ((MensajeEntrada=="lunes") || (MensajeEntrada=="martes") || (MensajeEntrada=="miercoles") ||
                (MensajeEntrada=="jueves") || (MensajeEntrada=="viernes") || (MensajeEntrada=="sabado") || (MensajeEntrada=="domingo"))
                {  
                    Respuesta = "ELIGE A QUE ::HORA:: QUIERES QUE SE NOTIFIQUE EL ::"+ p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada.ToString() +":: ESCRIBE\n"+
                        " CON EL SIGUIENTE FORMATO: \nHH:MM \n___";
                    
                    p.GuardarDiaDiaNotificacionAUsuario((Dias)Enum.Parse(typeof(Dias), MensajeEntrada, true),IDUsuario);
                    
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.GuardadoNotificacion;
                    
                }
                else
                {
                    Respuesta = "NO SE ENTENDIO DIA\nVUELVA A INTENTAR\nESCRIBA continuar\n___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideDiaFechaNotObjetivo;
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Error =true;
                }
                
            
            }
            else
            {
                Respuesta = "Listo";
                base.Manipular();
            }
 
        }
    }
}