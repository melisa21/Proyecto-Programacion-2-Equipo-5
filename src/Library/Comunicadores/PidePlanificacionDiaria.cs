using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PidePlanificacionDiaria: ConfiguracionNotificacion
    {
        public PidePlanificacionDiaria():base(){}
        
        public PidePlanificacionDiaria(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            
        
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PidePlanificacionDiaria)
            {

                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.ContenidoEntrada = p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia.ToString()
                +"\n"+MensajeEntrada;
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEscribirSinFormato;
                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Error=true;
                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia == Dias.Lunes)
                {
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia = Dias.Martes;
                    
                }
                else
                {
                    if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia == Dias.Martes)
                    {
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia = Dias.Miercoles;
                        
                    }
                    else
                    {
                        if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia == Dias.Miercoles)
                        {
                            p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia = Dias.Jueves;
                            
                        }
                        else
                        {
                            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia == Dias.Jueves)
                            {
                                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia = Dias.Viernes;
                                
                            }
                            else
                            {
                                if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia == Dias.Viernes)
                                {
                                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia = Dias.Sabado;
                                    
                                }
                                else
                                {
                                    
                                    if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dia == Dias.Sabado)
                                    {
                                        
                                        //guardar mensaje
                                        Mensaje msg = new Texto();
                                        msg.Contenido = MensajeEntrada;
                                        p.UsuariosDelPrograma[posUsr].BitacoraUsuario.GuardarMensajeEnEntrada(msg,p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada,DateTime.Today);
                                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.Comienzo;
                                        Respuesta = "SU ENTRADA QUEDO GUARDADA";                            
                                    }
        
                                }
                            }
                        }
                    }
                }
            
        
                        
            }
            else
            {
                Respuesta ="Fin guardado";
                base.Manipular();
            }
                
            
            
        }
    }
}