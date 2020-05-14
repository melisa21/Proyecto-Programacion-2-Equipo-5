using System;

/**************************************************************************
Aqui contemplamos el patron Singleton, necesitamos garanticar
que se cree una unica instancia de IUsuario y IPrograma
***************************************************************************/

namespace Library
{
    public class Fabrica
    {
        private static Fabrica instancia = null;
        private IUsuarios usrs = null;
        private IPrograma programa = null;

        private Fabrica()
        {
            this.usrs =new Usuarios();
            Bitacora b = new Bitacora();
            this.programa =new ProgramaEmisor(b);

        }

        public static Fabrica getInstancia()
        {
            if (instancia == null)
                instancia = new Fabrica();
            return instancia;
        }

    }
}