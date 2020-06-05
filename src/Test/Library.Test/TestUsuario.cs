using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace Library.Test
{
    public class TestUsuario
    {
        Usuario usuario;
        int cantidadTiposEntradasSoportadas = 4;

        [SetUp]
        public void Setup()
        {
            usuario = Usuario.GetUsuario();
        }

        [Test]
        public void UsuarioNoNull()
        {
            Assert.IsNotNull(usuario);
        }


        [Test]
        public void InstanciaSingletonUnica() 
        {
            Usuario usuariolocal = Usuario.GetUsuario();
            Assert.AreSame(usuariolocal, Usuario.GetUsuario());
        }

        [Test]
        public void ActualizacionDiasDesdeLista()
        {
            DiaNotificacion diaObjetivo = new DiaNotificacion(DiaNotificacion.TipoEntrada.objetivo, DiaNotificacion.Dias.Domingo, TimeSpan.Parse("20:00"));
            DiaNotificacion diaPlanificacion = new DiaNotificacion(DiaNotificacion.TipoEntrada.planificacion, DiaNotificacion.Dias.Sabado, TimeSpan.Parse("20:00"));
            DiaNotificacion diaReflexionSemanal = new DiaNotificacion(DiaNotificacion.TipoEntrada.reflexionsemanal, DiaNotificacion.Dias.Sabado, TimeSpan.Parse("20:00"));
            DiaNotificacion diaReflexionMetacognitiva = new DiaNotificacion(DiaNotificacion.TipoEntrada.reflexionmetacognitiva, DiaNotificacion.Dias.Sabado, TimeSpan.Parse("20:00"));
            List<DiaNotificacion> lista = new List<DiaNotificacion>{diaObjetivo, diaPlanificacion, diaReflexionSemanal, diaReflexionMetacognitiva};

            usuario.ActualizarDiasDesdeLista(lista);

            Assert.AreEqual(lista.Count, usuario.diasNotificacion.Count);
            Assert.AreEqual(cantidadTiposEntradasSoportadas, usuario.diasNotificacion.Count);
            Assert.AreEqual(diaObjetivo.Dia, usuario.diasNotificacion[0].Dia);
            Assert.AreEqual(diaPlanificacion.Tipo, usuario.diasNotificacion[1].Tipo);
            Assert.AreEqual(diaReflexionMetacognitiva.Hora, usuario.diasNotificacion[3].Hora);

        }

        [Test]
        public void ValidarNombre()
        {
            void PruebaCadenaVacia()
            {
                string vacio = "";
                Usuario.ValidarNombre(vacio);
            }

            void PruebaCadenaEspacios()
            {
                string espacios = "    ";
                Usuario.ValidarNombre(espacios);
            }

            void PruebaCadenaCorrecta()
            {
                string cadena = "  Juan  ";
                Usuario.ValidarNombre(cadena);
            }

            Assert.Throws(typeof(NombreVacioException), PruebaCadenaVacia);
            Assert.Throws(typeof(NombreVacioException), PruebaCadenaEspacios);
            Assert.DoesNotThrow(PruebaCadenaCorrecta);

        }
    }
}