namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class EleccionDia: ConfiguracionNotificacion
    {
        public EleccionDia(string mensajeEntrada, int iDUsuario):
            base(mensajeEntrada,iDUsuario)
        {}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            switch(MensajeEntrada)
            {
                case "1":
                        Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::OBJETIVO:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        
                                
                        
                        p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.Objetivo, IDUsuario);
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        
                        break;

            
                case "2":
                    Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::PLANIFICACION DIARIA:: ESCRIBE: \n"+
                    " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                    
                    p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.PlanificacionDiaria, IDUsuario);
                        
                    //buscar usuario en el programa asociado con el usuario de Telegram
                    //guardar en DiaNotificacion del usuario
                    
                    break;

                
                case "3":
                    Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION METACOGNITIVA:: ESCRIBE: \n"+
                    " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                    
                    //buscar usuario en el programa asociado con el usuario de Telegram
                    //guardar en DiaNotificacion del usuario
                    
                    p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.ReflexionMetacognitiva, IDUsuario);
                        
                    break;

                
                case "4":
                    Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION SEMANAL:: ESCRIBE: \n"+
                    " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                    
                    //buscar usuario en el programa asociado con el usuario de Telegram
                    //guardar en DiaNotificacion del usuario
                    
                    p.GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada.ReflexionSemanal, IDUsuario);
                    
                    break;
                
                default:
                    Respuesta = "No se entendio Entrada";
                    base.Manipular();
                    break;

            }
            
        }
    }
}