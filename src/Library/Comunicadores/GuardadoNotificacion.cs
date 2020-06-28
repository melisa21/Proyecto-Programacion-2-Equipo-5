using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class GuardadoNotificacion: ConfiguracionNotificacion
    {
        public GuardadoNotificacion(string mensajeEntrada, int iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
                
                Console.WriteLine("llega guardar");
                
                //Guardo Dia Notificacion en logica
                //Console.WriteLine(DiaNot.Hora);
                ProgramaEmisor p = ProgramaEmisor.GetInstancia();
                p.GuardarHoraDiaNotificacionAUsuario(TimeSpan.Parse(MensajeEntrada),IDUsuario);
                Respuesta = "Guardado";
                base.Manipular();
            
            
        }
    }
}