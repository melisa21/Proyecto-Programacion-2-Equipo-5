using System;
/*******************************
Se encargara de imprimir la salida y leer la entrada por Consola.
Esta clase se encarga de manejar la consola

*******************************/

namespace Library
{
    public class ComunicadorConsola
    {
        
        private static ComunicadorConsola instancia = null;



        public static void MainConsola()
        {
            while(true)
            {
                string mensajeEntrada = Console.ReadLine();
                if (instancia == null)
                    instancia =new ComunicadorConsola();
            
                instancia.ManejadorMensajesRecibidos(mensajeEntrada);
            }
        }

        


        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        public void ManejadorMensajesRecibidos(string mensajeEntradaOriginal)
        {
            string response="Disculpe, no entiendo";
            
            //leer de consola
            string mensajeEntrada = mensajeEntradaOriginal.ToLower();
             
            Console.WriteLine("Mesnaje Recibido de UsuarioConsola"+"saying "+mensajeEntrada);
            
            IManipulador comienzo = new Comienzo(mensajeEntrada,0);
            IManipulador escribirBitacora = new EscribirBitacora(mensajeEntrada,0);
            
            IManipulador eleccionEntrada = new EleccionEntrada(mensajeEntrada,0);
            IManipulador eleccionDia = new EleccionDia(mensajeEntrada,0);
            IManipulador eleccionHora = new EleccionHora(mensajeEntrada,0);
            IManipulador guardadoNotificacion = new GuardadoNotificacion(mensajeEntrada,0);
            
            switch(mensajeEntrada)
            {
                case "/start": 
                    comienzo.Manipular();
                    response = comienzo.Respuesta;
                
                break;

                case "escribir":
                    comienzo.CambiarSiguiente(escribirBitacora);
                    response = escribirBitacora.Respuesta;
                break;

                case "configurar":
                    comienzo.CambiarSiguiente(eleccionEntrada);
                    response = eleccionEntrada.Respuesta;
    
                    
                break;

                default:
                    if (mensajeEntrada == "1" || mensajeEntrada == "2" || mensajeEntrada == "3" || mensajeEntrada == "4")
                    {    
                        eleccionEntrada.CambiarSiguiente(eleccionDia);
                        response = eleccionDia.Respuesta;
                        
                    } 
                    else
                    {
                        if ((mensajeEntrada=="lunes") || (mensajeEntrada=="martes") || (mensajeEntrada=="miercoles") ||
                        (mensajeEntrada=="jueves") || (mensajeEntrada=="viernes") || (mensajeEntrada=="sabado") || (mensajeEntrada=="domingo"))
                        {
                            
                            eleccionDia.CambiarSiguiente(eleccionHora);
                            response = eleccionHora.Respuesta;
                        }
                        else
                        {
                            eleccionHora.CambiarSiguiente(guardadoNotificacion);
                            response = eleccionHora.Respuesta;
                            
                        }
                    }
                break;
            }
            Console.WriteLine(response);
        }

        public static void  ModeradroMensajeNotificacion(int idContacto, TipoEntrada entrada)
        {
            
            MensajesNotificatorios m = new MensajesNotificatorios(idContacto);
            m.Notificacion(entrada);
            string response = m.Respuesta;

            Console.WriteLine(response);
        }



    }
}
