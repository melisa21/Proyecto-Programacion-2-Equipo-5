using System;
namespace Library
{
    public abstract class Entrada
    {
        public Mensaje Contenido{ get; set;}
        public int DiaDeNotificacion {get; set;}
        public TimeSpan HoraDeNotificacion {get; set;}
        public Entrada (Mensaje msg){
            this.Contenido =msg;
        }
        
    }
}