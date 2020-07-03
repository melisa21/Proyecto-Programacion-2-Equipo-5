using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class MenuComienzo: ManipuladorBase
    {
        public MenuComienzo():base(){}
        
        public MenuComienzo(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();   
            
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.MenuComienzo)
            {
                if (MensajeEntrada == "escribir")
                {
                    Respuesta = "\nVAMOS A ESCRIBIR, ESCRIBE continuar\n"+
                    "___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribirBitacora;
                }
                else
                {
                    if (MensajeEntrada == "configurar")
                    {
                        Respuesta = "VAMOS A CONFIGURAR, ESCRIBE continuar"+
                        "___";
                    
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEntrada;
                    
                    }
                    else
                    {
                        Respuesta = "\nNo se esperaba que escribieras eso!!!\n";
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.Comienzo;
                    }
                }
            }
            else
            {
                base.Manipular();
            }
        }
    }
}