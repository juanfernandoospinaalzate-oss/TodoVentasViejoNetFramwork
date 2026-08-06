// -----------------------------------------------------------------------
// <copyright file="Kardex.Integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.Inventario.Integration.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class KardexIntegrationTests
    {
        private Fachada.Inventario.Kardex Fachadakardex = null;
        private Entidades.Kardex Registrokardex = null;

        [TestInitialize]
        public void SetUp()
        {
            this.Fachadakardex = new Fachada.Inventario.Kardex();
            this.Registrokardex = new Entidades.Kardex()
            {
                IdPresentacionArticulo = 0,
                CantidadEntrada = 0,
                CantidadSalida = 0,
                CostoUnitario = 5000,
                PrecioUnitario = 15000,
                TotalExistencias = 2,
                CostoTotal = 10000,
                PrecioTotal = 30000,
                Detalle = "Prueba Atomatizada",
                Fecha = DateTime.Now,
                Nombre = "Artículo de Prueba Automatizada"
            };
        }

        [TestMethod]
        public void ListarPorIdPresentacionArticulo_ConsultarPresentacionArticuloExistenteEnKardex_RetornaListaArticulosUnSoloElemento()
        {
            // La devolución de elementos es multiple, se pide solo uno por velocidad usando directiva de preprocesado
            int resultado = this.Fachadakardex.ListarPorIdPresentacionArticulo(1).Count;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void VerificarRelacionPresentacionArticulo_SeConsultaUnArticuloSinRegistros_RetornaFalse()
        {
            bool resultado = this.Fachadakardex.VerificarRelacionPresentacionArticulo(int.MinValue);
            Assert.AreEqual(resultado, false);
        }

        [TestMethod]
        public void VerificarRelacionPresentacionArticulo_SeConsultaUnArticuloConRegistros_RetornaTrue()
        {
            bool resultado = this.Fachadakardex.VerificarRelacionPresentacionArticulo(1);
            Assert.AreEqual(resultado, true);
        }

        /// <summary>
        /// Verifica que los datos inserten en la base de datos
        /// </summary>
        [TestMethod]
        public void Insertar_NuevoRegirstroEnKardexTodosLosCampos_RetornaNumeroRegistrosAfectadosUno()
        {
            this.Registrokardex.IdPresentacionArticulo = 1;
            this.Registrokardex.CantidadEntrada = 1;
            int resultado = this.Fachadakardex.Insertar(this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 1);
        }

        /// <summary>
        /// Se intenta ingresar un registro en el kardex pero la presentación de artículo no existe en la base de datos.
        /// </summary>
        [TestMethod]
        public void Insertar_NuevoRegirstroEnKardexPresentacionArtículoNoExiste_RetornaNumeroRegistrosAfectadosCero()
        {
            this.Registrokardex.IdPresentacionArticulo = 0; // No existe en base de datos
            int resultado = this.Fachadakardex.Insertar(Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        /// <summary>
        /// Si ambas cantidades, entrada y salida son cero simultaneamente, no se debe insertar registro
        /// </summary>
        [TestMethod]
        public void Isnertar_NuevoRegistroEnKardexCantidadEntradaCantidadSalidaSonCero_RetornaNumeroRegistrosAfectadosCero()
        { 
            this.Registrokardex.IdPresentacionArticulo = 1;
            this.Registrokardex.CantidadEntrada = 0;
            this.Registrokardex.CantidadSalida = 0;
            int resultado = this.Fachadakardex.Insertar(this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        /// <summary>
        /// Si ambas cantidades, entrada y salida son diferentes a cero simultaneamente, no se debe insertar el registro
        /// </summary>
        [TestMethod]
        public void Insertar_NuevoRegistroEnKardexCantidadEntradaCantidadSalidaNoSonCeroSimultanemente_RetornaNumeroRegistrosAfectadosCero()
        {
            this.Registrokardex.IdPresentacionArticulo = 1;
            this.Registrokardex.CantidadEntrada = 1;
            this.Registrokardex.CantidadSalida = 1;
            int resultado = this.Fachadakardex.Insertar(this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }
    }
#endif
}
