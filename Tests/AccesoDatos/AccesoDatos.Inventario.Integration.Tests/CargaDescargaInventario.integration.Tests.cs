// -----------------------------------------------------------------------
// <copyright file="CargaDescargaInventario.integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace AccesoDatos.Inventario.Integration.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
        public class CargaDescargaInventarioIntegrationTests
        {
            private Fachada.Inventario.CargaDescargaInventario FachadaCargaDescargaInventario = null;
            private string CodigoDeBarras = string.Empty;
            private Entidades.Kardex Kardex = null;

            [TestInitialize]
            public void SetUp()
            {
                this.FachadaCargaDescargaInventario = new Fachada.Inventario.CargaDescargaInventario();
                this.CodigoDeBarras = "096619926626";
                this.Kardex = new Entidades.Kardex()
                {
                    IdPresentacionArticulo = 1,
                    Fecha = DateTime.Now,
                    Nombre = "Omega 3 Kirkland 400 Capsulas Blandas 1.000 mg",
                    CantidadEntrada = 1,
                    CantidadSalida = 0,
                    PrecioUnitario = 100,
                    CostoUnitario = 50,
                    TotalExistencias = 10,
                    PrecioTotal = 1000,
                    CostoTotal = 500,
                    Detalle = "Prueba de integración"
                };
            }

            [TestMethod]
            public void Cargar_CargarCantidadCorrectamente_RetornaNumeroRegistrosAfectadosDos()
            {
                int resultado = this.FachadaCargaDescargaInventario.Cargar(this.CodigoDeBarras, 1, this.Kardex, true).RegistrosAfectados;
                Assert.AreEqual(resultado, 2);
            }

            [TestMethod]
            public void Cargar_UsarCodigoDeBarrasNoExistente_RetornaNumeroRegistrosAfectadosCero()
            {
                int resultado = this.FachadaCargaDescargaInventario.Cargar(int.MinValue.ToString(), 1, this.Kardex, false).RegistrosAfectados;
                Assert.AreEqual(resultado, 0);
            }

            [TestMethod]
            public void Cargar_UsarCantidadCero_RetornaNumeroRegistrosAfectadosCero()
            {
                int resultado = this.FachadaCargaDescargaInventario.Cargar(this.CodigoDeBarras, 0, this.Kardex, false).RegistrosAfectados;
                Assert.AreEqual(resultado, 0);
            }

            [TestMethod]
            public void DescarCargar_DescargarCantidadCorrectamente_RetornaNumeroRegistrosAfectadosDos()
            {
                this.Kardex.CantidadSalida = 1;
                this.Kardex.CantidadEntrada = 0;
                int resultado = this.FachadaCargaDescargaInventario.Descargar(this.CodigoDeBarras, 1, this.Kardex).RegistrosAfectados;
                Assert.AreEqual(resultado, 2);
            }

            [TestMethod]
            public void DescarCargar_UsarCodigoDeBarrasNoExistente_RetornaNumeroRegistrosAfectadosCero()
            {
                int resultado = this.FachadaCargaDescargaInventario.Descargar(int.MinValue.ToString(), 1, this.Kardex).RegistrosAfectados;
                Assert.AreEqual(resultado, 0);
            }

            [TestMethod]
            public void DescarCargar_UsarCantidadCero_RetornaNumeroRegistrosAfectadosCero()
            {
                int resultado = this.FachadaCargaDescargaInventario.Descargar(this.CodigoDeBarras, 0, this.Kardex).RegistrosAfectados;
                Assert.AreEqual(resultado, 0);
            }
        } 
#endif
}
