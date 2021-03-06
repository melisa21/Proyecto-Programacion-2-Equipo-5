using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideEscribirSinFormato: ManipuladorBase
    {
        public PideEscribirSinFormato():base(){}
        
        public PideEscribirSinFormato(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {

            ProgramaEmisor p = ProgramaEmisor.GetInstancia();   
            
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Error=false;
            
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideEscribirSinFormato) 
            {
                
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.PlanificacionDiaria)
                {
                    Respuesta = "¿Que piensas planificar para el"+p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia+"?\n"+
                        "___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo=EstadoDialogo.PidePlanificacionDiaria;
                }
                if( (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.ReflexionMetacognitiva)
                || (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.Objetivo) || 
                (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.ReflexionSemanal))
                {
                    Respuesta = "Escribe tu "+p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada+"\n"+
                        "___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo=EstadoDialogo.GuardarEscribirEntrada;
                }
            }
            else
            {
                base.Manipular();
            }
        }
    }
}