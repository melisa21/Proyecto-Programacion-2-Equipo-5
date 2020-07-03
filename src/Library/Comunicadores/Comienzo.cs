using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class Comienzo: ManipuladorBase
    {
        public Comienzo():base(){}
        public Comienzo(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PrimeraVez) 
            {
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.ConfigurarFechaFinalizacion;
                Respuesta = "Bienvenido!!!\nELIGE LA FECHA QUE FINALIZA LA BITACORA ESCRIBE CON EL SIGUIENTE FORMATO: dd/mm/aaaa \n"+
                        "___";
                
            }
            else
            {
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.Comienzo) 
                {
                  
                    Respuesta = "¡Bienvenido!\n ¿Qué quieres hacer?\n"+
                    " * SI QUIERES ESCRIBIR TU BITÁCORA ESCRIBE: escribir \n"+
                    "___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.MenuComienzo;  
                
                }
                else
                {
                    
                    base.Manipular();
            
                }    
            }
        }
    }
}