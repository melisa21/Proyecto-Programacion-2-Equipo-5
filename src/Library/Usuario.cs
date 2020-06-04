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
        public DiaNotificacion DiaObjetivo { get; private set;}
        public DiaNotificacion DiaPlanificacion { get; private set;}
        public DiaNotificacion DiaSemanal { get; private set;}
        public DiaNotificacion DiaMetacognitiva { get; private set;}
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
                DiaObjetivo = lista[0];
                DiaPlanificacion = lista[1];
                DiaSemanal = lista[2];
                DiaMetacognitiva = lista[3];
            }
            else
            {
                throw new ListaDeDiasInvalidaException();
            }
        }
    }
}