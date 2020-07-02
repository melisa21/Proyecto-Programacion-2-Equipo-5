namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideDia: ConfiguracionNotificacion
    {
        public PideDia():base(){}
        
        public PideDia(string mensajeEntrada, long iDUsuario):
            base(mensajeEntrada,iDUsuario)
        {}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario==EstadoDialogo.PideDia)
            {
                switch(MensajeEntrada)
                {
                    case "1":
                            
                            Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::OBJETIVO:: ESCRIBE: \n"+
                            " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                            
                                    
                            
                            p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.Objetivo, IDUsuario);
                            //buscar usuario en el programa asociado con el usuario de Telegram
                            //guardar en DiaNotificacion del usuario
                            p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.PideHora;
                            break;

                
                    case "2":
                        Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::PLANIFICACION DIARIA:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        
                        p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.PlanificacionDiaria, IDUsuario);
                            
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.PideHora;
                        break;

                    
                    case "3":
                        Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION METACOGNITIVA:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        
                        p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.ReflexionMetacognitiva, IDUsuario);
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.PideHora;    
                        break;

                    
                    case "4":
                        Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION SEMANAL:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        
                        p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.ReflexionSemanal, IDUsuario);
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.PideHora;
                        break;
                    default:
                        Respuesta = "Entrada invalido!!! Intenta nuevamente";
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.PideEntrada;
                    break;


                }
                
                        
            }
            else
            {
                Respuesta = "No se entendio Entrada";
                base.Manipular();
            }
        }
    }
}