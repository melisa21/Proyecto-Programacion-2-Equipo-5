using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class GuardarEscribirEntrada: ConfiguracionNotificacion
    {
        public GuardarEscribirEntrada():base(){}
        
        public GuardarEscribirEntrada(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            
        
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo == EstadoDialogo.GuardarEscribirEntrada)
            {

                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.ContenidoEntrada += p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia.ToString()
                + "\n" + MensajeEntrada;

                //Console.WriteLine(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.ContenidoEntrada);

                //guardar mensaje
                Mensaje msg = new Texto();
                msg.Contenido = MensajeEntrada;
                p.UsuariosDelPrograma[posUsr].BitacoraUsuario.GuardarMensajeEnEntrada(msg,p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada,DateTime.Today);
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.EscribioEntrada;
                Respuesta = "SU ENTRADA QUEDO GUARDADA";                            
            }
            else
            {
                Respuesta ="Fin guardado";
                base.Manipular();
            }
                
            
            
        }
    }
}