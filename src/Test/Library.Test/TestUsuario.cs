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