﻿
/*******************************
Se encargara de enviar y leer los mensajes de la conversacion por Telegram.
*******************************/

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Library
{
    public class ComunicadorTelegram 
    {

        /*private static ComunicadorTelegram instancia = null;
        
        private bool seEquivoco, terminoConfigurarMomentoNotificacion;
        private TipoEntrada entrada;

        private ComunicadorTelegram()
        {
            seEquivoco= false; terminoConfigurarMomentoNotificacion = false;
        }
        

        public static ComunicadorTelegram GetInstancia()
        {
            if (instancia == null)
                instancia = new ComunicadorTelegram();
            return instancia;
        }*/
      
        
        public void EnviarMensaje(){}
        public void RecibirMensaje(){}
        

        
        /// <summary>
        /// La instancia del bot.
        /// </summary>
        private static TelegramBotClient Bot;

        /// <summary>
        /// El token provisto por Telegram al crear el bot.
        ///
        /// *Importante*:
        /// Para probar este ejemplo, crea un bot nuevo y eeemplaza este 
        /// token por el de tu bot.
        /// </summary>
        private static string Token = "1255085361:AAFbg20-LCaF3O1BNXpPTSrOcPe4QLn93pY";

        /// <summary>
        /// Punto de entrada.
        /// </summary>
        public static void MainTelegram()
        {
            Bot = new TelegramBotClient(Token);
            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en _background_).
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            Console.WriteLine($"Bot is Up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo
        /// mensajes, ediciones de mensajes, respuestas a botones, etc. En este
        /// ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try 
            {
                // sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(update.Message);
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// Lo único que hacemos por ahora es escuchar 3 tipos de mensajes:
        /// - "hola": responde con texto
        /// - "chau": responde con texto
        /// - "foto": responde con una foto
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(Message message)
        {
            string response="Disculpe, no entiendo";
            string mensajeEntrada = message.Text.ToLower();
            
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");
            
            IManipulador comienzo = new Comienzo(mensajeEntrada);
            comienzo.Manipular();
            response = comienzo.Respuesta;
            await Bot.SendTextMessageAsync(message.Chat.Id, response);

            IManipulador escribirBitacora = new EscribirBitacora(mensajeEntrada);
            comienzo.CambiarSiguiente(escribirBitacora);
            response = escribirBitacora.Respuesta;
            await Bot.SendTextMessageAsync(message.Chat.Id, response);


            IManipulador eleccionEntrada = new EleccionEntrada(mensajeEntrada);
            comienzo.CambiarSiguiente(eleccionEntrada);
            response = eleccionEntrada.Respuesta;
            // enviamos el texto de respuesta
            await Bot.SendTextMessageAsync(message.Chat.Id, response);

            IManipulador eleccionDia = new EleccionDia(mensajeEntrada);
            eleccionEntrada.CambiarSiguiente(eleccionDia);
            response = eleccionDia.Respuesta;
            // enviamos el texto de respuesta
            await Bot.SendTextMessageAsync(message.Chat.Id, response);
            
            
            //try
            //{
                IManipulador eleccionHora = new EleccionHora(mensajeEntrada);
                eleccionDia.CambiarSiguiente(eleccionHora);
                response = eleccionHora.Respuesta;
                // enviamos el texto de respuesta
                await Bot.SendTextMessageAsync(message.Chat.Id, response);
            /*}
            catch (ArgumentException)
            {
                Console.WriteLine("Dia invalido, intente nuevamente: ");
            }*/
            
        }

        public static int DevolverUsuario(Message message)
        {
            
            Console.WriteLine("IdUsuario"+message.From.Id);
            return message.From.Id;
        }

        /*private static async Task HandleMessageSendNotification(Message message)
        {
            
            Console.WriteLine("Digo");
            
            Dialogo dialogo= Dialogo.GetInstancia();
            dialogo.NotificacionObjetivo();
            string response = dialogo.responde;

            // enviamos el texto de respuesta
            await Bot.SendTextMessageAsync(message.Chat.Id, response);
        }*/

        /// <summary>
        /// Envía una imágen como respuesta al mensaje recibido.
        /// Como ejemplo enviamos siempre la misma foto.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /*static async Task SendProfileImage(Message message)
        {
            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            const string filePath = @"profile.jpeg";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await Bot.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: new InputOnlineFile(fileStream, fileName),
                caption: "Te ves bien!"
            );
        }*/

        /// <summary>
        /// Manejo de excepciones. 
        /// Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }


    }
}