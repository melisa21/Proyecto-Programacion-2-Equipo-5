using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class TestSolicitudNotificacion
    {
        private SolicitudNotificacion sol;
        [SetUp]
        public void Setup()
        {
            sol = new SolicitudNotificacion();
        }

        [Test]
        public void ValidarTimer()
        {
            Assert.Throws(typeof(SolicitudNotificacionException), sol.crearSolicitud);
        }
        [Test]
        public void ValidarAgregarUsuario()
        {
            Usuario x = new Usuario();
            void agregarUsuario()
            {
                sol.AgregarNotificado(x);
            }
            Assert.Throws(typeof(SolicitudNotificacionException), agregarUsuario);
        }
    }
}