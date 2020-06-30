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
            
            int anio = Int32.Parse(MensajeEntrada.Substring(6));
            int mes = Int32.Parse(MensajeEntrada.Substring(3,2));
            int dia = Int32.Parse(MensajeEntrada.Substring(0,2));
            Console.WriteLine(anio+"m:"+mes+"d:"+dia);
            DateTime fechaFinal = new DateTime(anio,mes,dia,00,00,00);     
            p.GuardarFechaFinalizacionCurso(fechaFinal,IDUsuario);
            
            
            Respuesta = "Fecha de fializacion Guardada con exito\n Ahora debe configurar fecha de notificacion,para ello escriba: configurar";

            
        }
    }
}