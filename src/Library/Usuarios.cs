/***************************************
Considerando Expert Usuarios es la experta en manejar 
la coleccion correspondiente a Usuario, también tiene responsabilidad en esto
además contempla un a composición.
******************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class Usuarios: IUsuarios
    {
        private List<Usuario> usrs;

        public Usuarios()
        {
            this.usrs= new List<Usuario>();
        }

        public void agregarU(Usuario miembro)
        {
            this.usrs.Add(miembro);
        }

        public void removerU(Usuario miembro)
        {
            this.usrs.Remove(miembro);
        }


    }
}