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
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario == EstadoDialogo.ConfigurarFechaFinalizacion)
            {
                Console.WriteLine("llega");
                int anio = int.Parse(MensajeEntrada.Substring(6));
                int mes = int.Parse(MensajeEntrada.Substring(3,2));
                int dia = int.Parse(MensajeEntrada.Substring(0,2));
                Console.WriteLine(anio+"m:"+mes+"d:"+dia);
                DateTime fechaFinal = new DateTime(anio,mes,dia,00,00,00);     
                p.GuardarFechaFinalizacionCurso(fechaFinal,IDUsuario);
                p.CrearBitacora(IDUsuario);
                
                        
                Respuesta = "Fecha de fializacion Guardada con exito\n Ahora debe configurar fecha de notificacion,para ello escriba: configurar";
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario=EstadoDialogo.PideEntrada;
            }
            else
            {
                
                base.Manipular();
                
            }
        }
    }
}