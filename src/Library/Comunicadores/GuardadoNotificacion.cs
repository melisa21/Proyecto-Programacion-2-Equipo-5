using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class GuardadoNotificacion: ConfiguracionNotificacion
    {
        public GuardadoNotificacion():base(){}
        
        public GuardadoNotificacion(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
                
                //Guardo Dia Notificacion en logica
                
                ProgramaEmisor p = ProgramaEmisor.GetInstancia();
                p.GuardarHoraDiaNotificacionAUsuario(TimeSpan.Parse(MensajeEntrada),IDUsuario);
                Respuesta = "Guardado";
                base.Manipular();
            
            
        }
    }
}