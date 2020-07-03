using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library
{
    /// <summary>
    /// PersistorUsuarios es la clase encargada de persistir en archivos instancias de objetos Usuario y volver a crearlas desde ellos.
    /// Es un Singleton para que solo una instancia pueda existir al mismo tiempo, no es necesario tener varias en una clase con funciones de este tipo. Tambien podria haber sido una clase estatica.
    /// Es un Creator porque conoce toda la informacion necesaria para crear objetos Usuario.
    /// </summary>
    public class PersistorUsuarios
    {
        private static PersistorUsuarios persistorUsuarios;

        private string rutaCarpeta;

        IFormatter formatter = new BinaryFormatter();
        Stream stream;

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

        private Usuario CargarUsuario(string ruta)
        {
            stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            Usuario usuario = (Usuario)formatter.Deserialize(stream);
            stream.Close();

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

            stream = new FileStream(rutaUsuario, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, usuario);
            stream.Close();

        }
    }
}
