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
            usuario = new Usuario();
        }

        [Test]
        public void UsuarioNoNull()
        {
            Assert.IsNotNull(usuario);
        }



        [Test]
        public void ActualizacionDiasDesdeLista()
        {
            DiaNotificacion diaObjetivo = new DiaNotificacion(TipoEntrada.Objetivo, Dias.Domingo, TimeSpan.Parse("20:00"));
            DiaNotificacion diaPlanificacion = new DiaNotificacion(TipoEntrada.PlanificacionDiaria, Dias.Sabado, TimeSpan.Parse("20:00"));
            DiaNotificacion diaReflexionSemanal = new DiaNotificacion(TipoEntrada.ReflexionSemanal, Dias.Sabado, TimeSpan.Parse("20:00"));
            DiaNotificacion diaReflexionMetacognitiva = new DiaNotificacion(TipoEntrada.ReflexionMetacognitiva, Dias.Sabado, TimeSpan.Parse("20:00"));
            List<DiaNotificacion> lista = new List<DiaNotificacion>{diaObjetivo, diaPlanificacion, diaReflexionSemanal, diaReflexionMetacognitiva};

            usuario.ActualizarDiasDesdeLista(lista);

            Assert.AreEqual(lista.Count, usuario.DiasNotificacion.Count);
            Assert.AreEqual(cantidadTiposEntradasSoportadas, usuario.DiasNotificacion.Count);
            Assert.AreEqual(diaObjetivo.Dia, usuario.DiasNotificacion[0].Dia);
            Assert.AreEqual(diaPlanificacion.Tipo, usuario.DiasNotificacion[1].Tipo);
            Assert.AreEqual(diaReflexionMetacognitiva.Hora, usuario.DiasNotificacion[3].Hora);

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