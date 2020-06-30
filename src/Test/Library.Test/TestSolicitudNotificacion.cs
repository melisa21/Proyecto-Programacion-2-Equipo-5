using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

namespace Library.Test
{
    public class TestSolicitudNotificacion
    {
        private SolicitudNotificacion solicitud;
        private Usuario usuario;
        [SetUp]
        public void Setup()
        {
            solicitud = new SolicitudNotificacion();
            usuario = new Usuario();
        }

        [Test]
        public void ValidarNotificar()
        {
            Assert.Throws(typeof(SolicitudNotificacionException), solicitud.crearSolicitud);
        }
        [Test]
        public void ValidarAgregarUsuario()
        {
            void agregar()
            {
                solicitud.AgregarNotificado(usuario);
            }
            Assert.Throws(typeof(SolicitudNotificacionException), agregar);
        }
    }
}