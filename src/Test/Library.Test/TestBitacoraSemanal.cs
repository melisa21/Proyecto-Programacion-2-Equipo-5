using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestBitacoraSemanal
    {
        private BitacoraSemanal bitacoraSemanal ;

        [SetUp]
        public void Setup()
        {
            DateTime fecha = new DateTime(2020,06,01,00,00,00);
            bitacoraSemanal = new BitacoraSemanal(fecha);
        }

        [Test]
        public void EstadoSiguiente()
        {
            bitacoraSemanal.EstadoSiguiente();
            Assert.AreEqual( "encurso", bitacoraSemanal.Estado );
            
        }

        

    }
}