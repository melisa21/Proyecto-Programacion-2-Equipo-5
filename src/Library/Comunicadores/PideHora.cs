using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideHora: ConfiguracionNotificacion
    {
        public PideHora():base(){}
        
        public PideHora(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            
            while (true)
            {
                try
                {
                    Dias dia = (Dias)Enum.Parse(typeof(Dias), MensajeEntrada, true);
                    break;
                }
                catch (ArgumentException)
                {
                    Respuesta = "Dia invalido, intente nuevamente ";
                }
            }
            if ((MensajeEntrada=="lunes") || (MensajeEntrada=="martes") || (MensajeEntrada=="miercoles") ||
             (MensajeEntrada=="jueves") || (MensajeEntrada=="viernes") || (MensajeEntrada=="sabado") || (MensajeEntrada=="domingo"))
            {  
                Respuesta = "ELIGE A QUE ::HORA:: QUIERES QUE SE NOTIFIQUE EL ::"+ Entrada.ToString() +":: ESCRIBE\n"+
                    " CON EL SIGUIENTE FORMATO: \nHH:MM \n___";
                
                p.GuardarDiaDiaNotificacionAUsuario((Dias)Enum.Parse(typeof(Dias), MensajeEntrada, true),IDUsuario);
            }
            else
            {
                
                Respuesta = "Listo";
                
                base.Manipular();
            }
            
        }
    }
}