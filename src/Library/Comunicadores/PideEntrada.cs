using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class PideEntrada: ConfiguracionNotificacion
    {
        public PideEntrada():base(){}
        
        public PideEntrada(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);

            if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo==EstadoDialogo.PideEntrada)
            {
                if ((MensajeEntrada=="configurar"))
                {
                    Respuesta  = "ELIGE LA OPCION CORRESPONDIENTE A LA ENTRADA QUE QUIERES CONFIGURAR:\n"+
                        " 1. OBJETIVO\n 2. PLANIFICACION DIARIA \n 3. REFLEXION METACOGNITIVA\n 4. REFLEXION SEMANAL\n___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideDia;
                    
                    
                }
                else
                {
                    Respuesta = "No se entendio";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario.Dialogo = EstadoDialogo.PideEntrada;
                }
            }
            else
            {
                base.Manipular();
            }

            
        }
    }
}