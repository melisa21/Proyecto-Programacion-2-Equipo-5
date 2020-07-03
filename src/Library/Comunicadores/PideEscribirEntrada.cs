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
                  
                switch(MensajeEntrada)
                {  
                        
                    case "objetivo": 
                        Respuesta = " ESCRIBE UN OBJETIVO \n"+
                        "___";
                        //revisa formato
                        //si formato es escribir sin formato
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.Objetivo;
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEscribirSinFormato;
                    
                        
                        Console.WriteLine(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario);
                        break;

                    
                    case "diaria": 
                        Respuesta = " ESCRIBE continuar \n"+
                        "___";
                        
                        //revisa formato
                        //si formato es escribir sin formato
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.PlanificacionDiaria;
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEscribirSinFormato;
                        
                       
                        break;
                        
                    
                    case "metacognitiva": 
                        Respuesta = " ESCRIBE UNA REFLEXIÓN METACOGNITIVA \n"+
                        "___";
                        
                        //revisa formato
                        //si formato es escribir sin formato
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEscribirSinFormato;

                        
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.ReflexionMetacognitiva;
                        break;

                    
                    case "semanal": 
                        Respuesta = " ESCRIBE UNA REFLEXIÓN SEMANAL \n"+
                        "___";
                        
                        //revisa formato
                        //si formato es escribir sin formato
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEscribirSinFormato;
                        
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.ReflexionSemanal;
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