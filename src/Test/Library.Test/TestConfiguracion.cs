using NUnit.Framework;
using Library;
using System;
using System.IO;

namespace Library.Test
{
    public class TestConfiguracion
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CambiarNombreUsuario() 
        {
            Usuario usuario = new Usuario();
            Assert.IsNull(usuario.Nombre);
            
            string nombre = "Marina";
            var input = new StringReader(nombre);
            Console.SetIn(input);
            Configuracion.EstablecerNombre(usuario);

            Assert.AreEqual(nombre, usuario.Nombre);
        }

        [Test]
        public void CambiarPlataforma() 
        {
            Usuario usuario = new Usuario();

            string modo = "Consola";
            var input = new StringReader(modo);
            Console.SetIn(input);
            Configuracion.EstablecerPlataforma(usuario);

            Assert.AreEqual(ModoDeUso.Consola, usuario.modo);
        }
    }

    
}