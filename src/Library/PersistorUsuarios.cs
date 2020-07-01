using System;
using System.Collections.Generic;
using System.IO;

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

        private Usuario CargarUsuario(string ruta)
        {
            string[] informacion = File.ReadAllLines(ruta);

            Usuario usuario = new Usuario();

            for (int i = 0; i < informacion.Length; i++)
            {
                if (informacion[i].TrimEnd('\n') == "[info]")
                {
                    string cadena = informacion[i+1].TrimEnd('\n');
                    string[] datos = cadena.Split(',');
                    if(datos.Length == CantidadDatosInfo)
                    {
                        usuario.Nombre = datos[0];
                        usuario.IDContacto = long.Parse(datos[1]);
                    }
                    else
                    {
                        throw new ArchivoUsuarioInvalidoException();
                    }
                    i++;
                }
                else if (informacion[i].TrimEnd('\n') == "[diaN]")
                {
                    string cadena = informacion[i + 1].TrimEnd('\n');
                    string[] datos = cadena.Split(',');
                    if(datos.Length == CantidadDatosDiaN)
                    {
                        DiaNotificacion dia = new DiaNotificacion
                        {
                            Tipo = (TipoEntrada)Enum.Parse(typeof(TipoEntrada), datos[0], true),
                            Dia = (Dias)Enum.Parse(typeof(Dias), datos[1], true),
                            Hora = TimeSpan.Parse(datos[2])
                        };

                        usuario.AgregarDiaN(dia);
                    }
                    else
                    {
                        throw new ArchivoUsuarioInvalidoException();
                    }
                    i++;
                }
            }

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

            string cadenaInfo = "[info]\n" + $"{usuario.Nombre},{usuario.IDContacto}\n";
            
            List<string> listaCadenasDiaN = new List<string>();
            foreach (DiaNotificacion dia in usuario.DiasNotificacion)
            {
                string cadena = dia.ToString();
                listaCadenasDiaN.Add(cadena);
            }

            foreach  (string cadenaDiaN in listaCadenasDiaN)
            {
                cadenaInfo += "[diaN]\n" + cadenaDiaN + "\n";
            }

            File.WriteAllText(rutaUsuario, cadenaInfo);
        }
    }
}
