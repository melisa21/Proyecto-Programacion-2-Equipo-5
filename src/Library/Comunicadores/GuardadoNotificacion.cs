using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class GuardadoNotificacion: ConfiguracionNotificacion
    {
        public GuardadoNotificacion(string mensajeEntrada, int iDUsuario,DiaNotificacion diaNot):base(mensajeEntrada,iDUsuario, diaNot){}

        public override void Manipular()
        {
                
                Console.WriteLine("llega guardar");
                DiaNot.Hora = TimeSpan.Parse(MensajeEntrada);
                //Guardo Dia Notificacion en logica
                Console.WriteLine(DiaNot.Hora);
                ProgramaEmisor p = ProgramaEmisor.GetInstancia();
                if (p.BuscarUsuarioID(IDUsuario).Equals(-1))
                {
                    Usuario u = new Usuario();
                    u.IDContacto=IDUsuario;
                }
                p.GuardarDiaNotificacionAUsuario(DiaNot,IDUsuario);
                Respuesta = "Guardado";
                base.Manipular();
            
            
        }
    }
}