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

            
                if ((MensajeEntrada=="configurar") || (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario==EstadoDialogo.PideEntrada))
                {
                    Respuesta  = "ELIGE LA OPCION CORRESPONDIENTE A LA ENTRADA QUE QUIERES CONFIGURAR:\n"+
                        " 1. OBJETIVO\n 2. PLANIFICACION DIARIA \n 3. REFLEXION METACOGNITIVA\n 4. REFLEXION SEMANAL\n___";
                    p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.PideDia;
                    
                    
                }
                else
                {
                    Respuesta = "No se entendio";
                    base.Manipular();
                }
            

            
        }
    }
}