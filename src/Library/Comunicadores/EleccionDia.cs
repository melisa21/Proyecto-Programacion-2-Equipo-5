namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class EleccionDia: ManipuladorBase
    {
        public EleccionDia(string mensajeEntrada):base(mensajeEntrada){}

        public override void Manipular()
        {
            
            switch(MensajeEntrada)
            {
                case "1":
                        Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::OBJETIVO:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        Entrada = TipoEntrada.Objetivo;
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        
                        break;

            
                case "2":
                    Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::PLANIFICACION DIARIA:: ESCRIBE: \n"+
                    " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                    Entrada = TipoEntrada.PlanificacionDiaria;
                    //buscar usuario en el programa asociado con el usuario de Telegram
                    //guardar en DiaNotificacion del usuario
                    
                    break;

                
                case "3":
                    Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION METACOGNITIVA:: ESCRIBE: \n"+
                    " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                    Entrada = TipoEntrada.ReflexionMetacognitiva;
                    //buscar usuario en el programa asociado con el usuario de Telegram
                    //guardar en DiaNotificacion del usuario
                    
                    break;

                
                case "4":
                    Respuesta = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION SEMANAL:: ESCRIBE: \n"+
                    " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                    Entrada = TipoEntrada.ReflexionSemanal;
                    //buscar usuario en el programa asociado con el usuario de Telegram
                    //guardar en DiaNotificacion del usuario
                    
                    break;
                
                default:
                    Respuesta = "No se entendio Entrada";
                    base.Manipular();
                    break;

            }
            
        }
    }
}