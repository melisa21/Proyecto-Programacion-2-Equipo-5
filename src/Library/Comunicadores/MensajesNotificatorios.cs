using System;
namespace Library
{

    /// <summary>
    /// EsTA clasea 
    /// </summary>
    public class MensajesNotificatorios
    {
        
        public int IDUsuario{get;set;}
        public string Respuesta{get;set;}
        
        public MensajesNotificatorios(int iDUsuario)
        {
            this.IDUsuario = iDUsuario;
        }

        public void Notificacion(TipoEntrada entrada)
        {
            Respuesta = "Llego el momento de completar la entrada "+entrada.ToString()+
            "\nRecuerda que para ESCRIBIR UNA ENTRADA DE TU BITACORA DEBES ESCRIBIR EN EL CHAT: escribir";
            
        }
    }
}