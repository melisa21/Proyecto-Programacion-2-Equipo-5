using NUnit.Framework;
using Library;

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
            Assert.AreEqual(fechaSemana.DayOfWeek , DayOfWeek.Tuesday );
        }
    }
}