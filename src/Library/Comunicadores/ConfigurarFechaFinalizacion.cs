using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class ConfigurarFechaFinalizacion: ManipuladorBase
    {
        public ConfigurarFechaFinalizacion(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.ConfigurarFechaFinalizacion)
            {
                Console.WriteLine("llega");
                int anio = int.Parse(MensajeEntrada.Substring(6));
                int mes = int.Parse(MensajeEntrada.Substring(3,2));
                int dia = int.Parse(MensajeEntrada.Substring(0,2));
                Console.WriteLine(anio+"m:"+mes+"d:"+dia);
                DateTime fechaFinal = new DateTime(anio,mes,dia,00,00,00);     
                p.GuardarFechaFinalizacionCurso(fechaFinal,IDUsuario);
                p.CrearBitacora(IDUsuario);
                
                        
                Respuesta = "FECHA DE FINALIZACION GUARDADA CON EXITO\nAHORA DEBES CONFIGUAR FECHA NOTIFICACION ESCRIBE continuar";
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo=EstadoDialogo.PideFechaNotObjetivo;
            }
            else
            {
                Respuesta = "Error";
                base.Manipular();
                
            }
        }
    }
}