using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestProgramaEmisor
    {
        private ProgramaEmisor p = ProgramaEmisor.GetInstancia();

        [SetUp]
        public void Setup()
        {
            
        }

     

        [Test]
        public void PruebaBuscarUsuarioHayUno()
        {
            
            Usuario u2= new Usuario();
            p.UsuariosDelPrograma.Add(u2);

            Usuario u= new Usuario();
            u.IDContacto = 1;
            p.UsuariosDelPrograma.Add(u);
            
            
            int pos = p.BuscarUsuarioID(1);
            
            Assert.AreEqual(pos, 1);
        }
    }
}