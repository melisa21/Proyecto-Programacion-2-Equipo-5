namespace Library
{
    public abstract class Entrada
    {
        public Mensaje Contenido{ get; set;}

        public Entrada (Mensaje msg){
            this.Contenido =msg;
        }
        
    }
}