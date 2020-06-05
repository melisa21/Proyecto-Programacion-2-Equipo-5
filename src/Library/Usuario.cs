using System.Collections.Generic;

namespace Library
{
    public class Usuario
    {
        /// <summary>
        /// Usuario contiene informacion necesaria para el funcionamiento del bot como con que plataforma se quiere usar y en que dias se quiere ser notificado.
        /// Es un Singleton ya que contiene una instancia publica de si mismo que sera unica. 
        /// Lo es ya que nuestro bot esta pensado de forma que solo haya un usuario por instalacion. 
        /// </summary>
        private Usuario(){}

        private static Usuario usuario;

        private string nombre;
        public string Nombre 
        { 
            get
            {
                return this.nombre;
            } 
            set
            {
                if(ValidarNombre(value))
                {
                    this.nombre = value;
                }
            } 
        }
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

        public static bool ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new NombreVacioException();
            }
            else
            {
                return true;
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