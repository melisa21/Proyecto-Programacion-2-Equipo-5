using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    [Serializable]
    public class Usuario
    {

        private List<DiaNotificacion> diasNotificacion;

        /// <summary>
        /// Usuario contiene informacion necesaria para el funcionamiento del bot como con que plataforma se quiere usar y en que dias se quiere ser notificado.
        /// </summary>
        public Usuario()
        {
            this.BitacoraUsuario = new Bitacora();
            this.diasNotificacion = new List<DiaNotificacion>();

            this.EstadoDialogoUsuario = new DialogoUsuario();
        }

        private string nombre;
        
        [NonSerialized]
        private DialogoUsuario estadoDialogoUsuario;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (ValidarNombre(value))
                {
                    this.nombre = value;
                }
            }
        }


        public long IDContacto { get; set; }
        public ModoDeUso modo { get; set; }
        public List<DiaNotificacion> DiasNotificacion
        {
            get
            {
                return diasNotificacion;
            }
        }
        public void AgregarDiaN(DiaNotificacion dia)
        {
            diasNotificacion.Add(dia);
        }

        public void QuitarDiaN(DiaNotificacion dia)
        {
            diasNotificacion.Remove(dia);
        }

        public Bitacora BitacoraUsuario { get; set; }

        public DialogoUsuario EstadoDialogoUsuario { get => estadoDialogoUsuario; set => estadoDialogoUsuario = value; }


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



        /// <summary>
        /// Delega a la Bitacora con la correspondiente fecha la posibilidad
        /// de guardar el Mensaje como contenido de la entrada.
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        /// <param name="tipoEntrada">"objetivo" "planificaciondiaria" "reflexionsemanal" "reflexionmetacognitiva"</param>
        /// <param name="fecha">fecha de la bitacora semanal a a la que se quiere guardar la entrada</param>
        public void GuardarEnBitacora(Mensaje msg, TipoEntrada tipoEntrada, DateTime fecha)
        {
            //buscar biracora semenal con fecha 
            int indice = BitacoraUsuario.BuscarBitacoraSemanalPorFecha(fecha);
            BitacoraSemanal bitacoraSemanalEncontrada = BitacoraUsuario.BitacoraSemanals[indice];

            //guardarmensaje en la encontrada

            if (tipoEntrada == TipoEntrada.Objetivo)
            {
                bitacoraSemanalEncontrada.GuardarObjetivo(msg);
            }

            if (tipoEntrada == TipoEntrada.PlanificacionDiaria)
            {
                bitacoraSemanalEncontrada.GuardarPlanificacionDiaria(msg);
            }

            if (tipoEntrada == TipoEntrada.ReflexionSemanal)
            {
                bitacoraSemanalEncontrada.GuardarReflexionSemanal(msg);
            }

            if (tipoEntrada == TipoEntrada.ReflexionMetacognitiva)
            {
                bitacoraSemanalEncontrada.GuardarReflexionMetacognitiva(msg);
            }

        }

        public void ImprimirConsolaUsuario()
        {
            Console.WriteLine(IDContacto);
            foreach (var item in DiasNotificacion)
            {
                Console.WriteLine("Entrada " + item.Tipo.ToString() + " Dia " + item.Dia.ToString() + " Hora " + item.Hora);
            }
        }

        /// <summary>
        /// Verificar cuales son las tareas pendientes
        /// dependiendo de los diaNotificacion del usuario
        /// y un DateTime cualquiera.
        /// </summary>
        /// <param name="diaYHoraActual"></param>
        public List<DiaNotificacion> TareasPendientes(DateTime diaYHoraActual)
        {
            List<DiaNotificacion> tareas = new List<DiaNotificacion>();

            TimeSpan tiempoActual = diaYHoraActual.TimeOfDay;
            int horaActual = tiempoActual.Hours;
            int minutoActual = tiempoActual.Minutes;
            int diaActual = (int)diaYHoraActual.DayOfWeek;

            foreach (DiaNotificacion diaNot in this.diasNotificacion)
            {
                TimeSpan tiempoNotificacion = diaNot.Hora;
                int horaNotificacion = tiempoNotificacion.Hours;
                int minutoNotificacion = tiempoNotificacion.Minutes;

                bool esElDia = ((int)diaNot.Dia == diaActual);
                bool esLaHora = (horaActual == horaNotificacion);
                bool esElMinuto = (minutoActual == minutoNotificacion);

                if (esElDia && esLaHora && esElMinuto)
                {
                    tareas.Add(diaNot);
                }
            }

            return tareas;
        }
    }
}