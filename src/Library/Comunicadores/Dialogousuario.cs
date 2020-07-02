using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// </summary>
    public class DialogoUsuario
    {
        public EstadoDialogo Dialogo{get;set;}
        public bool Error{get;set;}

        public TipoEntrada Entrada{get;set;}
        public DialogoUsuario()
        {
            Dialogo = EstadoDialogo.PrimeraVez;
            Error = false;
            Entrada = TipoEntrada.Objetivo;
        }
    }
}


