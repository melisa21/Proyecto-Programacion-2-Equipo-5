using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideEscribirEntrada: ManipuladorBase
    {
        public PideEscribirEntrada():base(){}
        
        public PideEscribirEntrada(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();   
            
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.PideEscribirEntrada) 
            {
                
                Console.WriteLine("entra a pide Entrada");
                    
                switch(MensajeEntrada)
                {  
                    case "objetivo": 
                        Console.WriteLine("entra objetivo");
                        Respuesta = " ESCRIBE UN OBJETIVO \n"+
                        "___";
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribioEntrada;
                        
                        Console.WriteLine(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario);
                        break;

                    
                    case "diaria": 
                        Respuesta = " ESCRIBE UNA PLANIFICACIÓN DIARIA \n"+
                        "___";
                        
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribioEntrada;

                        break;
                        
                    
                    case "metacognitiva": 
                        Respuesta = " ESCRIBE UNA REFLEXIÓN METACOGNITIVA \n"+
                        "___";
                        
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribioEntrada;

                        break;

                    
                    case "semanal": 
                        Respuesta = " ESCRIBE UNA REFLEXIÓN SEMANAL \n"+
                        "___";
                        
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribioEntrada;

                        break;
                    
                    case "salir": 
                        Respuesta = "\nChauuuuu!!!\n";
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.Comienzo;                    
                        break;

                    default:
                        Respuesta = "\nNo se esperaba que escribieras eso como entrada a escribir!!!\n";
                        
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribirBitacora;
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Error= true;
                        
                        break;
                }
                    
            }
            else
            {
                base.Manipular();
            }
        }
    }
}