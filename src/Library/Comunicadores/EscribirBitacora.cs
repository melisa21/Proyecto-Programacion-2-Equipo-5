using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class EscribirBitacora: ManipuladorBase
    {
        public EscribirBitacora(string mensajeEntrada, int iDUsuario):base(mensajeEntrada,iDUsuario){}

        public override void Manipular()
        {
            
            switch(MensajeEntrada)
            {
                
                case "escribir": 
                    Respuesta = " * SI QUIERES ESCRIBIR EL OBJETIVO ESCRIBE: escribir objetivo \n"+
                    " * SI QUIERES ESCRIBIR LA PLANIFICACION DIARIA ESCRIBE: escribir diaria \n"+
                    " * SI QUIERES ESCRIBIR LA REFLEXION METACOGNITIVA ESCRIBE: escribir metacognitiva \n"+
                    " * SI QUIERES ESCRIBIR LA REFLEXION SEMANAL ESCRIBE: escribir semanal \n"+
                    " * SI QUIERES SALIR DEL BOT ESCRIBE: salir \n"+
                    "___";
                    
                    break;
                
                case "escribir objetivo": 
                    Respuesta = " ESCRIBE UN OBJETIVO \n"+
                    "___";
                    break;

                
                case "escribir diaria": 
                    Respuesta = " ESCRIBE UNA PLANIFICACIÓN DIARIA \n"+
                    "___";
                    break;
                
                
                case "escribir metacognitiva": 
                    Respuesta = " ESCRIBE UNA REFLEXIÓN METACOGNITIVA \n"+
                    "___";
                    break;

                
                case "escribir semanal": 
                    Respuesta = " ESCRIBE UNA REFLEXIÓN SEMANAL \n"+
                    "___";
                    break;



                default:
                    Respuesta = "No se puede";
                    base.Manipular();
                    break;
            }

            
        }
    }
}