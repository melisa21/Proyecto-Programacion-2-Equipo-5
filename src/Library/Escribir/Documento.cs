using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Documento
    {
        public Documento()
        {

        }
        public abstract void EscribirDocumento(List<Mensaje> datosEspeciales1);
    }
}