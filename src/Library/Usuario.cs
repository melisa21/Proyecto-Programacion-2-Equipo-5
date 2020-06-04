using System.Collections.Generic;

namespace Library
{
    public class Usuario
    {
        private Usuario()
        {
            diasNotificacion = new List<DiaNotificacion>{DiaObjetivo, DiaPlanificacion, DiaSemanal, DiaMetacognitiva};
        }

        private static Usuario usuario;
        public string Nombre { get; set; }
        public string IDContacto { get; set; }
        public ModoDeUso modo { get; set; }
        public DiaNotificacion DiaObjetivo { get; set; }
        public DiaNotificacion DiaPlanificacion { get; set; }
        public DiaNotificacion DiaSemanal { get; set; }
        public DiaNotificacion DiaMetacognitiva { get; set; }
        public List<DiaNotificacion> diasNotificacion {get; set;}

        public static Usuario GetUsuario()
        {
            if (usuario == null)
            {
                usuario = new Usuario();
            }
            return usuario;
        }

        public enum ModoDeUso
        {
            Consola,
            Telegram
        }

        public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new NombreVacioException();
            }
        }
    }
}