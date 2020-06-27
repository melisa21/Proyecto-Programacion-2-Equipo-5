using System;

namespace Library
{
    public class Dialogo
    {
        private static Dialogo instancia = null;

        private bool seEquivoco, terminoConfigurarMomentoNotificacion;
        private TipoEntrada entrada;

        public string Responde{get;set;}

        public string MensajeEntrada{get;set;}

        private Dialogo()
        {
            seEquivoco= false; terminoConfigurarMomentoNotificacion = false;
        }

        public static Dialogo GetInstancia()
        {
            if (instancia == null)
                instancia = new Dialogo();
            return instancia;
        }
      
        public string NotificacionObjetivo()
        {
            return " ES MOMENTO DE ESCRIBIR OBJETIVOS \n";
        }

        public string NotificacionPlanificaciónDiaria()
        {
            return " ES MOMENTO DE ESCRIBIR PLANIFICACIÓN DIARIA \n";
        }

        public string NotificacionReflexionMetacognitiva()
        {
            return " ES MOMENTO DE ESCRIBIR REFLEXIóN METACOGNITIVA \n";
        }

        public string NotificacionReflexionSemanal()
        {
            return " ES MOMENTO DE ESCRIBIR REFLEXIÓN SEMANAL \n";
        }
        
        public void FlujoUsuarioEntraAPlataforma()
        {
            if ((MensajeEntrada=="lunes") || (MensajeEntrada=="martes") || (MensajeEntrada=="miercoles") ||
             (MensajeEntrada=="jueves") || (MensajeEntrada=="viernes") || (MensajeEntrada=="sabado") || (MensajeEntrada=="domingo"))
            {   
                Responde = "ELIGE A QUE ::HORA:: QUIERES QUE SE NOTIFIQUE EL ::"+ entrada.ToString() +":: ESCRIBE\n"+
                    " CON EL SIGUIENTE FORMATO: \nHH:MM:SS \n___";
                //buscar usuario en el programa asociado con el usuario de Telegram
                //guardar en DiaNotificacion del usuario
                terminoConfigurarMomentoNotificacion = true;
            }
            else
            {
                switch(MensajeEntrada)
                {
                    case "/start": 
                        Responde = "¡Bienvenido!\n ¿Qué quieres hacer?\n"+
                        " * SI QUIERES ESCRIBIR TU BITÁCORA ESCRIBE: escribir \n"+
                        " * SI QUIERES CONFIGURAR EL MOMENTO DE NOTIFICACIÓN DE LAS ENTRADAS ESCRIBE: configurar\n"+
                        " * SI QUIERES SALIR DEL BOT ESCRIBE: salir \n"+
                        "___";
                        this.seEquivoco = false;
                        break;

                    case "escribir": 
                        Responde = " * SI QUIERES ESCRIBIR EL OBJETIVO ESCRIBE: escribir objetivo \n"+
                        " * SI QUIERES ESCRIBIR LA PLANIFICACION DIARIA ESCRIBE: escribir diaria \n"+
                        " * SI QUIERES ESCRIBIR LA REFLEXION METACOGNITIVA ESCRIBE: escribir metacognitiva \n"+
                        " * SI QUIERES ESCRIBIR LA REFLEXION SEMANAL ESCRIBE: escribir semanal \n"+
                        " * SI QUIERES SALIR DEL BOT ESCRIBE: salir \n"+
                        "___";
                        this.seEquivoco = false;
                        break;
                    
                    case "escribir objetivo": 
                        Responde = " ESCRIBE UN OBJETIVO \n"+
                        "___";
                        this.seEquivoco = false;
                        break;

                    
                    case "escribir diaria": 
                        Responde = " ESCRIBE UNA PLANIFICACIÓN DIARIA \n"+
                        "___";
                        this.seEquivoco = false;
                        break;
                    
                    
                    case "escribir metacognitiva": 
                        Responde = " ESCRIBE UNA REFLEXIÓN METACOGNITIVA \n"+
                        "___";
                        this.seEquivoco = false;
                        break;

                    
                    case "escribir semanal": 
                        Responde = " ESCRIBE UNA REFLEXIÓN SEMANAL \n"+
                        "___";
                        this.seEquivoco = false;
                        break;

                    case "configurar": 
                        Responde = "ELIGE LA OPCION CORRESPONDIENTE A LA ENTRADA QUE QUIERES CONFIGURAR:\n"+
                        " 1. OBJETIVO\n 2. PLANIFICACION DIARIA \n 3. REFLEXION METACOGNITIVA\n 4. REFLEXION SEMANAL\n___";
                        this.seEquivoco = false;
                        break;
                    
                    case "1":
                        Responde = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::OBJETIVO:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        entrada = TipoEntrada.Objetivo;
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        this.seEquivoco = false;
                        break;

                    case "2":
                        Responde = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::PLANIFICACION DIARIA:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        entrada = TipoEntrada.PlanificacionDiaria;
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        this.seEquivoco = false;
                        break;

                    
                    case "3":
                        Responde = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION METACOGNITIVA:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        entrada = TipoEntrada.ReflexionMetacognitiva;
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        this.seEquivoco = false;
                        break;

                    
                    case "4":
                        Responde = "ELIGE QUE ::DÍA:: QUIERES QUE SE NOTIFIQUE EL ::REFLEXION SEMANAL:: ESCRIBE: \n"+
                        " lunes, martes, miercoles,\n jueves, viernes, sabado o domingo\n___";
                        entrada = TipoEntrada.ReflexionSemanal;
                        //buscar usuario en el programa asociado con el usuario de Telegram
                        //guardar en DiaNotificacion del usuario
                        this.seEquivoco = false;
                        break;

                    case "salir": 
                        Responde = "Chau! Que andes bien!";
                        break;

                    default: 
                        Console.WriteLine(seEquivoco+"Terminoconf"+terminoConfigurarMomentoNotificacion);
                        if ( seEquivoco==false && terminoConfigurarMomentoNotificacion==true)
                        {
                            Responde ="TU CONFIGURACION DE NOTIFICACIÓN A SIDO GUARDADA";
                            this.seEquivoco = false;
                        }
                        else
                        {
                            Responde = "Disculpa, no se qué hacer con ese mensaje!";
                            this.seEquivoco = true;
                        }
                        Console.WriteLine(seEquivoco+"Terminoconf"+terminoConfigurarMomentoNotificacion);
                        
                        break;
                }
            }
            
            
        }
    }
}