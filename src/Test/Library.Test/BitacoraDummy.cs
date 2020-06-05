using System;

namespace Library.Test
{
    public class BitacoraDummy
    {
        

        public static Bitacora CrearBitacoraSemanalDummy()
        {
            Bitacora bitacora = Bitacora.GetInstancia();
            int cantidadSemanas = 2;
            DateTime fechaHoy = DateTime.Today;
            bitacora.FechaFinDeCurso = fechaHoy.AddDays(cantidadSemanas*7);
            bitacora.CrearBitacoraSemanal();
            return bitacora;
        }
    }

}