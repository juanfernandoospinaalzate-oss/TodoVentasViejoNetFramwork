// -----------------------------------------------------------------------
// <copyright file="PresentacionArticuloWeb.Integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace Fachada.WebPublica.Integration.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class PresentacionArticuloWebIntegrationTests
    {
        Fachada.WebPublica.PresentacionArticulo PresentacionArticulo = null;

        [TestInitialize]
        public void setup()
        {
            this.PresentacionArticulo = new Fachada.WebPublica.PresentacionArticulo();
        }

        [TestMethod]
        public void ListarPendientesActualizacion_ConsultarPresentacionesPendientesPorActualizar_RetornaListaPresentacionArticulosUnoOceroElementos()
        {
            int resultado = this.PresentacionArticulo.ListarPendientesActualizacion().Count;
            Assert.IsTrue(resultado == 0 || resultado == 1);
        }

        [TestMethod]
        public void Listar_ConsultaTodasLasPresentacionesArticuloParaMostrarSitioWeb__RetornaListaPresentacionesArticuloUnSoloElemento()
        {
            int resultado = this.PresentacionArticulo.Listar().Count;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void ListarPorIdArticulo_ConsultaLasPresentacionesUsandoelIdArticulo_RetornaListaPresentacionesArticuloUnSoloElemento()
        {
            int resultado = this.PresentacionArticulo.ListarPorIdArticulo(1).Count;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void ConsultarPorIdPresentacionArticulo_ConsultaLaPresentacionDeARticuloUsandoelIdPresentacionArticulo()
        {
            int resultado = this.PresentacionArticulo.ConsultarPorIdPresentacionArticulo(1).IdPresentacionArticulo; // TODO: EL MÉTODO QUE SE EVALÚA NO HA SIDO IMPLEMENTADO CORRECTAMENTE
            Assert.AreEqual(resultado, 1);
        }
    } 
#endif
}
