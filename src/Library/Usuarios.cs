using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class Usuarios: IUsuarios
    {
        private IList<Usuario> usrs;

        public Usuarios()
        {
            this.usrs= null;
        }
    }
}