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
            Assert.AreEqual( BitacoraSemanal.TipoEstado.Finalizada, bitacoraSemanal.Estado );
            
        }

        /*
        [Test]
        public void GuardarMensajeEnEntrada()
        {
            Mensaje texto = new Texto();
            bitacoraSemanal.GuardarMensajeEnEntrada(texto,"objetivo");
            Assert.AreEqual( 0, bitacoraSemanal.ListObjetivo.FindIndex((Objetivo o) => o.Contenido.Equals(texto)) );
            
        }*/


        

    }
}