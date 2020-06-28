using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class TestSolicitudNotificacion
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void CasoPositivo()
        {
            Dias diaDeLaSemana = (Dias)4;
            TipoEntrada tipoDeEntrada = (TipoEntrada)1;
            TimeSpan horaDeNot = new TimeSpan(23,0,0);
            DiaNotificacion dia = new DiaNotificacion(tipoDeEntrada, diaDeLaSemana, horaDeNot);
            bool esMomento = SolicitudNotificacion.EsMomentoDeNotificar(dia, new DateTime(2020, 6, 4, 23, 0, 0));
            Assert.IsTrue(esMomento);
        }
        [Test]
        public void CasoNegativo()
        {
            Dias diaDeLaSemana = (Dias)4;
            TipoEntrada tipoDeEntrada = (TipoEntrada)1;
            TimeSpan horaDeNot = new TimeSpan(20,20,0);
            DiaNotificacion dia = new DiaNotificacion(tipoDeEntrada, diaDeLaSemana, horaDeNot);
            bool esMomento = SolicitudNotificacion.EsMomentoDeNotificar(dia, new DateTime(2020, 6, 4, 23, 0, 0));
            Assert.IsFalse(esMomento);
        }
    }
}