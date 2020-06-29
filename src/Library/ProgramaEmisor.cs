using System;
using System.Collections.Generic;

namespace Library
{

    /// <summary>
    /// EsTA clase debe seguir SINGLETON dado que permite asegurarse de que ProgramaEmisor
    /// tenga solo una instancia. Además no necesitamos
    ///  mas de una instancia esto generaria un conflicto
    /// Ademas, teniendo en cuanta EXPERT, esta tiene la informacion
    ///  necesaria para crear las bitacora que se necesita la cual tambien es singleton
    /// De este se crea en configuracion
    /// </summary>
    public class ProgramaEmisor
    {
        
        
        private static ProgramaEmisor instancia = null;

        private List<Usuario> usuarios;

        public List<Usuario> UsuariosDelPrograma
        {
            get
            {
                return usuarios;
            }
        }


        /// <summary>
        /// ProgramaEmisor en el encargado de comunicarse con el usuario a traves del comunicador.
        /// </summary>
        /// <param name="name">Nombre del objeto</param>
        private ProgramaEmisor()
        {
            this.usuarios = new List<Usuario>();   
        }

        /// <summary>
        /// Metodo propio de haberlo definido segun Singleton.
        /// </summary>
        public static ProgramaEmisor GetInstancia()
        {
            if (instancia == null)
                instancia = new ProgramaEmisor();
            return instancia;
        }

      


        /// <summary>
        /// Delega a el comunicador el envio del mensaje para el usuario
        /// </summary>
        public void EnviarMensajeNotificacion(int idContacto, TipoEntrada entrada)
        {
            int i = this.BuscarUsuarioID(idContacto);
            if (this.UsuariosDelPrograma[i].modo == ModoDeUso.Telegram)
                ComunicadorTelegram.HandleMessageSendNotification(idContacto,entrada);
            else
                ComunicadorConsola.ModeradroMensajeNotificacion(idContacto,entrada);


        }


        public int BuscarUsuarioID(int idContacto)
        {
            int indice = this.UsuariosDelPrograma.FindIndex((Usuario u) => u.IDContacto.Equals(idContacto));
            return indice;
        }
        
        public void GuardarDiaNotificacionAUsuario(DiaNotificacion diaNotificacion, int IDUsuario)
        {
            
            int i= this.BuscarUsuarioID( IDUsuario);
            
            
            if (i!=-1)
            {
                this.UsuariosDelPrograma[i].DiasNotificacion.Add(diaNotificacion);
                Console.WriteLine(this.UsuariosDelPrograma[i].DiasNotificacion);
            }
            else
            {
                Usuario u= new Usuario();
                u.IDContacto = IDUsuario;
                u.DiasNotificacion.Add(diaNotificacion);
                this.UsuariosDelPrograma.Add(u);
            }
            //this.ImprimirConsolaUsuarios();
        }

        public void GuardarTipoEntradaDiaNotificacionAUsuario(TipoEntrada entrada, int IDUsuario)
        {
            
                DiaNotificacion diaNotificacion= new DiaNotificacion();
                diaNotificacion.Tipo = entrada; 
                GuardarDiaNotificacionAUsuario(diaNotificacion, IDUsuario);
                //this.ImprimirConsolaUsuarios();
        }

        public void GuardarDiaDiaNotificacionAUsuario(Dias dia, int IDUsuario)
        {
            int i= this.BuscarUsuarioID( IDUsuario);
            int cantidad= this.UsuariosDelPrograma[i].DiasNotificacion.Count;
            this.UsuariosDelPrograma[i].DiasNotificacion[cantidad-1].Dia = dia;
            //this.ImprimirConsolaUsuarios();
        }

        public void GuardarHoraDiaNotificacionAUsuario(TimeSpan hora, int IDUsuario)
        {
            
            int i= this.BuscarUsuarioID( IDUsuario);
            int cantidad= this.UsuariosDelPrograma[i].DiasNotificacion.Count;
            this.UsuariosDelPrograma[i].DiasNotificacion[cantidad-1].Hora = hora;
            //ImprimirConsolaUsuarios();
        }
        public void ImprimirConsolaUsuarios()
        {
            foreach (var item in this.UsuariosDelPrograma)
            {
                item.ImprimirConsolaUsuario();
                Console.WriteLine("......");
            }
        }
    }
}