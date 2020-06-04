using System;

namespace Library
{
    public abstract class Entrada
    {
        public string Estado{get; set;}
        public Mensaje Contenido{ get; set;}
        public DateTime DiaDeLaSemanaYHorario{get; set;}

        public Entrada (Mensaje msg){
            this.Estado = "vacio";
            this.Contenido = msg;
        }
        
    }
}