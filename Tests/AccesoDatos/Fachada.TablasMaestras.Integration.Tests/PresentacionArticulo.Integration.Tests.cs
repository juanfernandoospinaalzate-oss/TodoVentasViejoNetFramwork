// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.Integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.TablasMaestras.Integration.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class PresentacionArticuloIntegrationTests
    {
        private Entidades.PresentacionArticulo Presentacion = null;
        private Fachada.TablasMaestras.PresentacionArticulo FachadaPresentacionArticulo = null;
        private Entidades.Kardex Registrokardex = null;

        [TestInitialize]
        public void SetUp()
        {
            this.FachadaPresentacionArticulo = new Fachada.TablasMaestras.PresentacionArticulo();
            this.Presentacion = new Entidades.PresentacionArticulo()
            {
                Activo = true,
                Articulo = new Entidades.Articulo() { IdArticulo = 1 },
                CodigoEAN = "096619926626",
                Color = new Entidades.Color() { IdColor = 1 },
                CostoArticulo = 0,
                DescripcionBreve = "Aceite de pescado bla bla bla",
                EnLinea = true,
                Existencias = 0,
                Fecha = DateTime.Now,
                FechaFinalDescuento = DateTime.Now,
                FechaInicioDescuento = DateTime.Now,
                FechaProximoVencimiento = DateTime.Now,
                IdPresentacionArticulo = 12551,
                Imagen1 = new byte[] { 1, 2, 3 },
                Imagen2 = null,
                Imagen3 = null,
                Imagen4 = null,
                Imagen5 = null,
                Imagen6 = null,
                Nombre = "Fish Oil Omega 3 Kirkland",
                Precio = 164000,
                PreOrden = true,
                Sabor = new Entidades.Sabor() { IdSabor = 1 },
                Talla = new Entidades.Talla() { IdTalla = 1 },
                UnidadLongitud = new Entidades.UnidadLongitud() { IdUnidadLongitud = 1 },
                UnidadMasa = new Entidades.UnidadMasa() { IdUnidadMasa = 1 },
                UnidadPresentacion = new Entidades.UnidadPresentacion() { IdUnidadPresentacion = 4 },
                UnidadVolumen = new Entidades.UnidadVolumen() { IdUnidadVolumen = 1 },
                UsarDescuento = false,
                UsarFechaProximoVencimiento = false,
                UsarPorcentajeDescuento = false,
                UsarValorFijoDescuento = false,
                ValorFijoDescuento = 0,
                ValorPorcentajeDescuento = 0,
                VlrContenidoVolumetrico = 0,
                VlrUnidadLongitud = 0,
                VlrUnidadMasa = 0,
                VlrUnidadPresentacion = 0,
                VlrUnidadVolumenAncho = 0,
                VlrUnidadVolumenLargo = 0,
                VlrUnidadVolumenProfundidad = 0
            };

            this.Registrokardex = new Entidades.Kardex()
            {
                IdPresentacionArticulo = 1,
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
        public void Insertar_NuevoRegistroPresentacionArticulo_RetornaNumeroRegistrosAfectadosDos()
        {
            this.Presentacion.CodigoEAN = "096619926626Nuevo";
            this.Presentacion.IdPresentacionArticulo = 0;
            this.Registrokardex.IdPresentacionArticulo = 0;
            this.Registrokardex.CantidadEntrada = 0; // Puede ser igual o superior a cero
            this.Registrokardex.CantidadSalida = 0; // Al insertar siempre tiene que ser sero
            int Resultado = this.FachadaPresentacionArticulo.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(Resultado, 2);
        }

        [TestMethod]
        public void Insertar_CodigoDeBarrasYaExistente_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.IdPresentacionArticulo = 1;
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.CodigoEAN = "096619926626";
            this.Presentacion.Nombre = "Fish Oil Omega 3 Kirkland";
            int resultado = this.FachadaPresentacionArticulo.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_RegistroPresentacionArticuloExistente_RetornaNumeroRegistrosAfectadosDos()
        {
            this.Presentacion.IdPresentacionArticulo = 1;
            this.Presentacion.CodigoEAN = "096619926626";
            this.Registrokardex.CantidadEntrada = 0; // Puede ser igual o superior a cero
            this.Registrokardex.CantidadSalida = 0; // Al insertar siempre tiene que ser sero
            int Resultado = this.FachadaPresentacionArticulo.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(Resultado, 2);
        }

        [TestMethod]
        public void Actualizar_ActualizaUnCodigoDeBarrasAOtroYaExistenteEnotroGenerandoUnDuplicado_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.IdPresentacionArticulo = 2; // este apunta al triple omega de nature made
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.CodigoEAN = "096619926626"; // apunta al omega 3 de kirkland
            this.Presentacion.Nombre = "Fish Oil Omega 3 Kirkland";
            int resultado = this.FachadaPresentacionArticulo.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void ListarPoirIdArticulo_ConsularPresentacionesDelArticuloPorIdArticulo_RetornaListaPresentacionesArticuloUnSoloElemento()
        {
            int resultado = this.FachadaPresentacionArticulo.Listar(1).Count;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void ListarPendientesActualizacion_ConsultarPresentacionesPendientesPorActualizar_RetornaListaPresentacionArticulosUnoOceroElementos()
        {
            int resultado = this.FachadaPresentacionArticulo.ListarPendientesActualizacion().Count;
            Assert.IsTrue(resultado == 0 || resultado == 1);
        }

        [TestMethod] 
        public void ListarActivos_ConsultarListaPresentacionesArticuloActivas_RetornaListaPresentacionArticuloUnSoloElemento()
        {
            int resultado = this.FachadaPresentacionArticulo.ListarActivos().Count;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void ListarTodo_ConsultarListaCompletaPresentacionesArticulo_RetornaListaPresentacionArticuloUnSoloElemento()
        {
            int resultado = this.FachadaPresentacionArticulo.ListarTodo().Count;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void ConsultarPorIdPresentacionArticulo_ConsultaUtilizandoIdPresentacionArticuloExistente_RetornaEntidadPresentacionArticuloEcontrada()
        {
            int resultado = this.FachadaPresentacionArticulo.ConsultarPorId(1).IdPresentacionArticulo;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void ConsultarPorCodigoEAN_ConsultaUtilizandoCodigoEanExistente_RetornaEntidadPresentacionArticuloEcontrada()
        {
            int resultado = this.FachadaPresentacionArticulo.ConsultarPresentacionPorCodigoEAN("096619926626").IdPresentacionArticulo;
            Assert.AreEqual(resultado, 1);
        }
    } 
#endif
}
