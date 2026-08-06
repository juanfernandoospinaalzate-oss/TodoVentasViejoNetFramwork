using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TablasMaestras.UnitTest
{
#if Pruebas
    [TestClass]
    public class MarcaUnitTests
    {
        Entidades.Marca Marca = null;
        Validacion.TablasMaestras.Marca ValidacionMarca = null;

        [TestInitialize]
        public void SetUp()
        {
            this.Marca = new Entidades.Marca();
            this.ValidacionMarca = new Validacion.TablasMaestras.Marca();
        }

        [TestMethod]
        public void Insertar_MarcaStringVacio_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = string.Empty;
            int resultado = this.ValidacionMarca.Insertar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_MarcaStringNulo_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = null;
            int resultado = this.ValidacionMarca.Insertar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_MarcaStringSoloEspaciosVacios_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = "   ";
            int resultado = this.ValidacionMarca.Insertar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_MarcaStringMasDeVeinteCaracteres_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = "01234567890123456789X";
            int resultado = this.ValidacionMarca.Insertar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        //_______________________________________________________________________________________

        [TestMethod]
        public void ListarPorNombre_MarcaStringVacio_RetornaRegisrtosRecuperadosCero()
        {
            int resultado = this.ValidacionMarca.ListarPorNombre(string.Empty).Count;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void ListarPorNombre_MarcaStringNulo_RetornaRegisrtosRecuperadosCero()
        {
            int resultado = this.ValidacionMarca.ListarPorNombre(null).Count;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void ListarPorNombre_MarcaStringSoloEspaciosVacios_RetornaRegisrtosAfectadosCero()
        {
            int resultado = this.ValidacionMarca.ListarPorNombre("   ").Count;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void ListarPorNombre_MarcaStringMasDeVeinteCaracteres_RetornaRegisrtosAfectadosCero()
        {
            int resultado = this.ValidacionMarca.ListarPorNombre("01234567890123456789X").Count;
            Assert.AreEqual(resultado, 0);
        }

        //___________________________________________________________________________________________

        [TestMethod]
        public void Actualizar_MarcaStringVacio_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = string.Empty;
            int resultado = this.ValidacionMarca.Actualizar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_MarcaStringNulo_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = null;
            int resultado = this.ValidacionMarca.Actualizar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_MarcaStringSoloEspaciosVacios_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = "   ";
            int resultado = this.ValidacionMarca.Actualizar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_MarcaStringMasDeVeinteCaracteres_RetornaRegisrtosAfectadosCero()
        {
            this.Marca.Nombre = "01234567890123456789X";
            int resultado = this.ValidacionMarca.Actualizar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }
    } 
#endif
}
