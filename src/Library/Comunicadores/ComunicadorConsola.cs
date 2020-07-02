using System;
/*******************************
Se encargara de imprimir la salida y leer la entrada por Consola.
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
                Console.WriteLine();
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
            string mensajeEntrada = mensajeEntradaOriginal.ToLower();
             
            //Console.WriteLine("Mesnaje Recibido de UsuarioConsola"+"saying "+mensajeEntrada);
            
            ControladoraDialogo dialogo = ControladoraDialogo.GetInstancia();
            string response = dialogo.GenerarRespuesta(mensajeEntrada, 0);
            
            Console.WriteLine(response);
        }

        public static void  ModeradroMensajeNotificacion(long idContacto, TipoEntrada entrada)
        {
            
            MensajesNotificatorios m = new MensajesNotificatorios(idContacto);
            m.Notificacion(entrada);
            string response = m.Respuesta;

            Console.WriteLine(response);
        }



    }
}