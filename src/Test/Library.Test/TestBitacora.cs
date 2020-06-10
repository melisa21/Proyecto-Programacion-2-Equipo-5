using NUnit.Framework;
using System;

namespace Library.Test
{
    public class TestBitacora
    {
        private Bitacora bitacora = BitacoraDummy.CrearBitacoraSemanalDummy();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CorrerFechaALunesDevuelveLunes()
        {   
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaSemana = bitacora.CorrerFechaALunes(fechaHoy);
            Assert.AreEqual(fechaSemana.DayOfWeek , DayOfWeek.Monday );
            
        }

        
        [Test]
        public void CrearBitacoraSemanalPrueba2semanas()
        {
            Assert.AreEqual(bitacora.BitacoraSemanals[0].Fecha, bitacora.CorrerFechaALunes(DateTime.Today));
            Assert.AreEqual( bitacora.BitacoraSemanals[1].Fecha , bitacora.CorrerFechaALunes(DateTime.Today).AddDays(7) );
            Assert.AreEqual( 2 , bitacora.BitacoraSemanals.Count );   
        }

    
        [Test]
        public void BuscarBitacoraSemanalPorFecha()
        {

            DateTime fechaABuscar = new DateTime(2020,06,15,00,00,00);
            Assert.AreEqual( bitacora.BuscarBitacoraSemanalPorFecha(fechaABuscar) , 1 );   
        
        }

        

        

    }
}