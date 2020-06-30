using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class Usuario
    {
        
        private List<DiaNotificacion> diasNotificacion;

        /// <summary>
        /// Usuario contiene informacion necesaria para el funcionamiento del bot como con que plataforma se quiere usar y en que dias se quiere ser notificado.
        /// Es un Singleton ya que contiene una instancia publica de si mismo que sera unica. 
        /// Lo es ya que nuestro bot esta pensado de forma que solo haya un usuario por instalacion. 
        /// </summary>
        public Usuario()
        {
            this.BitacoraUsuario = new Bitacora();
            this.diasNotificacion = new List<DiaNotificacion>();
        }

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
        public long IDContacto { get; set; }
        public ModoDeUso modo { get; set; }
        public List<DiaNotificacion> DiasNotificacion
        {
            get
            {
                return diasNotificacion;
            }
        }
        public Bitacora BitacoraUsuario {get; set;}


       

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

            if (tipoEntrada == TipoEntrada.ReflexionSemanal )
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
                Console.WriteLine("Entrada "+item.Tipo.ToString()+" Dia "+item.Dia.ToString()+" Hora "+item.Hora);
            }
        }
    }  
}