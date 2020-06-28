using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class EleccionHora: ConfiguracionNotificacion
    {
        public EleccionHora(string mensajeEntrada, int iDUsuario,DiaNotificacion diaNot):base(mensajeEntrada,iDUsuario, diaNot){}

        public override void Manipular()
        {
            if ((MensajeEntrada=="lunes") || (MensajeEntrada=="martes") || (MensajeEntrada=="miercoles") ||
             (MensajeEntrada=="jueves") || (MensajeEntrada=="viernes") || (MensajeEntrada=="sabado") || (MensajeEntrada=="domingo"))
            {  
                Respuesta = "ELIGE A QUE ::HORA:: QUIERES QUE SE NOTIFIQUE EL ::"+ Entrada.ToString() +":: ESCRIBE\n"+
                    " CON EL SIGUIENTE FORMATO: \nHH:MM \n___";
                
                
                DiaNot.Dia = (Dias)Enum.Parse(typeof(Dias), MensajeEntrada, true);
            }
            else
            {
                Console.WriteLine("llega eleccion hora else");
                Respuesta = "Listo";
                
                base.Manipular();
            }
            
        }
    }
}