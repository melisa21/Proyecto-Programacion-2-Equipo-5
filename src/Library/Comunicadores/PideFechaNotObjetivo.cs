using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideFechaNotObjetivo: ConfiguracionNotificacion
    {
        public PideFechaNotObjetivo():base(){}
        
        public PideFechaNotObjetivo(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);

            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PideFechaNotObjetivo)
            {
                    Respuesta  = "ESCRIBE continuar";

                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideDiaFechaNotObjetivo;
            }
            else
            {
                Respuesta  = "ESCRIBE continuar";
                base.Manipular();
            }

            
        }
    }
}