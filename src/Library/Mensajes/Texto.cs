namespace Library
{
    public class Texto : Mensaje
    {
        public string Txt {get; set;}
        public IFormato Formato {get; set;}
        public Texto(){}

        public string GenerarMensaje()
        {
            string salida="No entiendo, algo esta mal!";
            if (this.Txt.Equals("/"))
                salida = "¡Bienvenido!\n Si quieres escribir tu bitacora escribe: si \n"+
                ": ";
            if (this.Txt.Equals("si"))
                salida = "*Menu escribir entrada*\n"+ 
                "Selecciona la opcion correspondiente a la entrada que quieres escribir\n "+
                "1. Objetivo\n"+
                "2. Planificación Diaria\n"+
                "3. Reflexión Semanal\n"+
                "4. Reflexión Metacognitiva\n"+
                "Opción: ";
            if (this.Txt.Equals("2"))
            {
                salida = ".:Seleccionaste Escribir Planificación Diaria:.\n "+
                "¿Qué día quieres planificar: lunes, martes, miércoles, jueves o viernes?\n"+
                "Escribe el dia: ";
            }
            return salida;
        }

    }
}