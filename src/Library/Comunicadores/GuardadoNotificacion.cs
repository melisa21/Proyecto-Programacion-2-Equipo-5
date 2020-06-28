using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class GuardadoNotificacion: ManipuladorBase
    {
        public GuardadoNotificacion(string mensajeEntrada):base(mensajeEntrada){}

        public override void Manipular()
        {
            
                Respuesta = "Guardado";
                Hora = TimeSpan.Parse(MensajeEntrada);
                

                base.Manipular();
            
            
        }
    }
}