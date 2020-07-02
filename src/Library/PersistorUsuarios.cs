using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Library
{
    public class PersistorUsuarios
    {
        private PersistorUsuarios()
        {
            string rutaExe = AppDomain.CurrentDomain.BaseDirectory;
            rutaCarpeta = rutaExe + @"/Usuarios";
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            CrearUsuarioConsola();
        }
        private static PersistorUsuarios persistorUsuarios;

        private string rutaCarpeta;

        private static int CantidadDatosInfo = 2;
        private static int CantidadDatosDiaN = 3;

        public static PersistorUsuarios GetPersistorUsuarios()
        {
            if (persistorUsuarios == null)
            {
                persistorUsuarios = new PersistorUsuarios();
            }
            return persistorUsuarios;
        }
        
        public List<Usuario> CargarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            string[] archivos = System.IO.Directory.GetFiles(rutaCarpeta, "*.usuario");

            foreach (string archivo in archivos)
            {
                Usuario usuario  = CargarUsuario(archivo);
                lista.Add(usuario);
            }

            return lista;
        }

        private void CrearUsuarioConsola()
        {
            string rutaUsuario = rutaCarpeta + @"/0.usuario";
            if(!File.Exists(rutaUsuario))
            {
                Usuario usuario = new Usuario
                {
                    Nombre = "Consola",
                    IDContacto = 0
                };
                GuardarUsuario(usuario);
            }
        }

        public Usuario CargarUsuario(string ruta)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            Usuario usuario = (Usuario)formatter.Deserialize(stream);

            return usuario;
        }

        public void GuardarUsuarios(List<Usuario> listaUsuarios)
        {
            foreach (Usuario usuario in listaUsuarios)
            {
                GuardarUsuario(usuario);
            }
        }

        private void GuardarUsuario(Usuario usuario)
        {
            string rutaUsuario = rutaCarpeta + @$"/{usuario.IDContacto}.usuario";

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(rutaUsuario, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, usuario);
            stream.Close();

        }
    }
}
