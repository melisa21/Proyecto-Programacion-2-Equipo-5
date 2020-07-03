namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideDiaFechaNotObjetivo: ConfiguracionNotificacion
    {
        public PideDiaFechaNotObjetivo():base(){}
        
        public PideDiaFechaNotObjetivo(string mensajeEntrada, long iDUsuario):
            base(mensajeEntrada,iDUsuario)
        {}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            
            p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Error =false;
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PideDiaFechaNotObjetivo)
            {
                           
                Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::"+p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada+":: ESCRIBE: \n"+
                " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                
                p.GuardarTipoEntradaDiaNotificacionAUsuario(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada, IDUsuario);  
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo=EstadoDialogo.PideHoraFechaNotObjetivo;
                        
            }
            else
            {
                Respuesta = "No se entendio dia";
                base.Manipular();
            }
        }
    }
}