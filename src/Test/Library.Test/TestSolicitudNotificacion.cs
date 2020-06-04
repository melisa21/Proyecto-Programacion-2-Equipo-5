using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Library.Test
{
    public class TestSolicitudNotificacion
    {
        private SolicitudNotificacion solicitud;
        private Entrada entrada;

        [SetUp]
        public void Setup()
        {
            entrada = new Objetivo(new Texto());
            solicitud = new SolicitudNotificacion(new List<Entrada>{entrada});
        }

        [Test]
        public void CasoPositivo()
        {
            entrada.DiaDeNotificacion = 4;
            entrada.HoraDeNotificacion = new TimeSpan(23,0,0);
            bool esMomento = SolicitudNotificacion.esMomentoDeNotificar(entrada, new DateTime(2020, 6, 4, 23, 0, 0));
            Assert.IsTrue(esMomento);
        }
        [Test]
        public void CasoNegativo()
        {
            entrada.DiaDeNotificacion = 5;
            entrada.HoraDeNotificacion = new TimeSpan(23,0,0);
            bool esMomento = SolicitudNotificacion.esMomentoDeNotificar(entrada, new DateTime(2020, 6, 4, 23, 0, 0));
            Assert.IsFalse(esMomento);
        }
    }
}