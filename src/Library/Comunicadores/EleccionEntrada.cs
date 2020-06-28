using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class EleccionEntrada: ManipuladorBase
    {
        public EleccionEntrada(string mensajeEntrada):base(mensajeEntrada){}

        public override void Manipular()
        {
            
            switch(MensajeEntrada)
            {
                case "configurar":
                    Respuesta  = "ELIGE LA OPCION CORRESPONDIENTE A LA ENTRADA QUE QUIERES CONFIGURAR:\n"+
                        " 1. OBJETIVO\n 2. PLANIFICACION DIARIA \n 3. REFLEXION METACOGNITIVA\n 4. REFLEXION SEMANAL\n___";
                    
                break;

                default:
                    Respuesta = "No se entendio";
                    base.Manipular();
                    break;
            }

            
        }
    }
}