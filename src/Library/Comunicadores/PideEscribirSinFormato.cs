using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideEscribirTabla: ManipuladorBase
    {
        public PideEscribirTabla():base(){}
        
        public PideEscribirTabla(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {

            ProgramaEmisor p = ProgramaEmisor.GetInstancia();   
            
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Error=false;
            
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideEscribirSinFormato) 
            {
                
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.PlanificacionDiaria)
                {
                    Respuesta = Respuesta = "¿Que piensas planificar para el"+p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia+"?\n"+
                        "___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo=EstadoDialogo.PidePlanificacionDiaria;
                }
            }
            else
            {
                base.Manipular();
            }
        }
    }
}