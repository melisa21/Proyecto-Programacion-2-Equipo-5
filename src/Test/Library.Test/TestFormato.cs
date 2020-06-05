using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestFormato
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void FormatoTablaCorrecto()
        {
            Tabla t = new Tabla();
            Assert.AreEqual(t.FormatearEntrada("Tabla"), "Entrada formateada tabla=  Tabla");
        }

        public void FormatoVinietaCorrecto()
        {
            Tabla t = new Tabla();
            Assert.AreEqual(t.FormatearEntrada("Viñeta"), "\t\u2022 Entrada formateada viñeta = Viñeta");
        }
    }
}