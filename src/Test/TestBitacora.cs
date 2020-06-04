using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestBitacora
    {
        private Bitacora bitacora = Bitacora.GetInstance();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CorrerFechaALunesDevuelveLunes()
        {
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaSemana = bitacora.CorrerFechaALunes(fechaHoy);
            Assert.Equals(fechaSemana.DayOfWeek , DayOfWeek.Tuesday );
        }
    }
}