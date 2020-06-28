using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class EleccionHora: ManipuladorBase
    {
        public EleccionHora(string mensajeEntrada):base(mensajeEntrada){}

        public override void Manipular()
        {
            if ((MensajeEntrada=="lunes") || (MensajeEntrada=="martes") || (MensajeEntrada=="miercoles") ||
             (MensajeEntrada=="jueves") || (MensajeEntrada=="viernes") || (MensajeEntrada=="sabado") || (MensajeEntrada=="domingo"))
            {  
                Respuesta = "ELIGE A QUE ::HORA:: QUIERES QUE SE NOTIFIQUE EL ::"+ Entrada.ToString() +":: ESCRIBE\n"+
                    " CON EL SIGUIENTE FORMATO: \nHH:MM \n___";
                
                Dia = (Dias)Enum.Parse(typeof(Dias), MensajeEntrada, true);
            }
            else
            {
                Respuesta = "Listo";
                Hora = TimeSpan.Parse(MensajeEntrada);
                base.Manipular();
            }
            
        }
    }
}