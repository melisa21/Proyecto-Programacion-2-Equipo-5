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
                int posUsr =p.BuscarUsuarioID(IDUsuario);
            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.GuardadoNotificacion)
            {
                p.GuardarHoraDiaNotificacionAUsuario(TimeSpan.Parse(MensajeEntrada),IDUsuario);
                Respuesta = "GUARDADO DIA NOTIFICACION DE "+p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada+"\n Escribe algo para continuar";
                
                
                if(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.Objetivo)
                {
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.PlanificacionDiaria;
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideDiaFechaNotObjetivo;
                    
                }
                else
                {
                    if(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.PlanificacionDiaria)
                    {
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.ReflexionMetacognitiva;
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideDiaFechaNotObjetivo;
                    }
                    else
                    {
                        
                        if(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.ReflexionMetacognitiva)
                        {
                            p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.ReflexionSemanal;
                            p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideDiaFechaNotObjetivo;
                        }
                        else
                        {
                            if(p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada==TipoEntrada.ReflexionSemanal)
                            {
                                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Entrada = TipoEntrada.Objetivo;
                                p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo=EstadoDialogo.GuardoFechaNotObjetivo;
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