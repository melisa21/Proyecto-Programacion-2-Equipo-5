using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class Comienzo: ManipuladorBase
    {
        public Comienzo():base(){}
        public Comienzo(string mensajeEntrada, long iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            
            ProgramaEmisor p = ProgramaEmisor.GetInstancia();
            int posUsr =p.BuscarUsuarioID(IDUsuario);

            switch(MensajeEntrada)
            {
                
                case "/start": 
                    
                    if (posUsr==-1) //ingreso por primera vez
                    {
                        Usuario u= new Usuario();
                        u.IDContacto = IDUsuario;
                        p.UsuariosDelPrograma.Add(u);
                        posUsr =p.BuscarUsuarioID(IDUsuario);
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.ConfigurarFechaFinalizacion;
                        
                        Console.WriteLine("Comienzo");
                        this.Respuesta = "Bienvenido!!!\nELIGE LA FECHA QUE FINALIZA LA BITACORA ESCRIBE CON EL SIGUIENTE FORMATO: dd/mm/aaaa \n"+
                                "___";
                    }
                    else
                    {
                        
                        Console.WriteLine("Comienzo else");
                        Respuesta = "¡Bienvenido!\n ¿Qué quieres hacer?\n"+
                        " * SI QUIERES ESCRIBIR TU BITÁCORA ESCRIBE: escribir \n"+
                        " * SI QUIERES CONFIGURAR EL MOMENTO DE NOTIFICACIÓN DE LAS ENTRADAS ESCRIBE: configurar\n"+
                        " * SI QUIERES SALIR DEL BOT ESCRIBE: salir \n"+
                        "___";
                        p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario = EstadoDialogo.Comienzo;
                        
                    }
                    break;

                default:
                    if (p.UsuariosDelPrograma[posUsr].EstadoDialogoUsuario == EstadoDialogo.Comienzo)
                        Respuesta = "Fin";
                    base.Manipular();
                    break;
                
            }
            
        }
    }
}