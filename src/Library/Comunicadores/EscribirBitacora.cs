using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class EscribirBitacora: ManipuladorBase
    {
        public EscribirBitacora():base(){}
        
        public EscribirBitacora(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();   
            
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.EscribirBitacora)
            {
                Respuesta = " * SI QUIERES ESCRIBIR EL OBJETIVO ESCRIBE: objetivo \n"+
                    " * SI QUIERES ESCRIBIR LA PLANIFICACION DIARIA ESCRIBE: diaria \n"+
                    " * SI QUIERES ESCRIBIR LA REFLEXION METACOGNITIVA ESCRIBE: metacognitiva \n"+
                    " * SI QUIERES ESCRIBIR LA REFLEXION SEMANAL ESCRIBE: semanal \n"+
                    " * SI QUIERES SALIR DE ESTE MENU ESCRIBE: salir \n"+
                    "___";
                
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEscribirEntrada;
            }
            else
            {
                Respuesta = "\nNo se esperaba que escribieras eso!!!\n";
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribirBitacora;
                base.Manipular();
            }
            
        }
    }
}