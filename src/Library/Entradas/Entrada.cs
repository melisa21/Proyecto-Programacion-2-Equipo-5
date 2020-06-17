using System;
namespace Library
{
    /// <summary>
    /// Por SRP, Entrada tiene la responsabilidad
    ///  sobre las funcionalidades de las misma
    /// las cuales comparten sus subclases
    /// Por Expert, esta clase tiene la responsabilidad
    ///  dado que es el experto en el contenido y el estado de esta
    /// cumpliendo la responsabilidad de manipular esta informacion
    /// </summary>
    public class Entrada
    {
        
        

        //****************************************
        public TipoEstado Estado{get; set;}
        public Mensaje Contenido{ get; set;}
        public int DiaDeNotificacion {get; set;}
        public TimeSpan HoraDeNotificacion {get; set;}
        public DateTime DiaDeLaSemanaYHorario{get; set;}
        //****************************************


        /// <summary>
        /// Entrada de la Bitacora sin contenido
        /// </summary>
        public Entrada (){
            this.Estado = TipoEstado.Vacia;
        }   


        /// <summary>
        /// Entrada de la Bitacora. Contenido queda bajo posible modificacion
        /// </summary>
        /// <param name="msg">contenido de la entrada obtenida a traves de mensaje con anterioridad</param>
        /// <param name="name">Nombre del objeto</param>
        public Entrada (Mensaje msg){
            this.Estado = TipoEstado.Finalizada;
            this.Contenido = msg;
        }


        
        /// <summary>
        /// Cambia el estado de la entrada, dandola como terminada
        /// </summary>
        public void TerminarEntrada()
        {
            this.Estado = TipoEstado.Finalizada;
        }       
    }
}