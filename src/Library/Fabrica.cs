using System;

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
            this.programa =new ProgramaEmisor();

        }

        public static Fabrica getInstancia()
        {
            if (instancia == null)
                instancia = new Fabrica();
            return instancia;
        }

    }
}