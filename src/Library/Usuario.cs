using System.Collections.Generic;

namespace Library
{
    public class Usuario
    {
        private Usuario(){}

        private static Usuario usuario;
        public string Nombre { get; set; }
        public string IDContacto { get; set; }
        public ModoDeUso modo { get; set; }
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

        public void ActualizarDiasDesdeLista(List<DiaNotificacion> lista)
        {
            if(lista.Count == 4)
            {
                DiaNotificacion diaObjetivo = lista[0];
                DiaNotificacion diaPlanificacion = lista[1];
                DiaNotificacion diaReflexionSemanal = lista[2];
                DiaNotificacion diaReflexionMetacognitiva = lista[3];
                diasNotificacion = new List<DiaNotificacion>{diaObjetivo, diaPlanificacion, diaReflexionSemanal, diaReflexionMetacognitiva};
            }
            else
            {
                throw new ListaDeDiasInvalidaException();
            }
        }
    }
}