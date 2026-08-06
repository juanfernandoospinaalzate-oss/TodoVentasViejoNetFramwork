// -----------------------------------------------------------------------
// <copyright file="Facturacion.Integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.Facturacion.Integration.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class FacturacionIntegrationTests
    {
        Fachada.Facturacion.Facturacion FachadaFacturacion = null;

        [TestInitialize]
        public void SetUp()
        {
            this.FachadaFacturacion = new Fachada.Facturacion.Facturacion();
        }

        [TestMethod]
        public void ConsultarPresentacionPorCodigoEAN_ConsularPresentaciónExistentePorCodigoDeBarras_RetornaPrimeraPresentacionEncontrada()
        {
            int resultado = this.FachadaFacturacion.ConsultarPresentacionPorCodigoEAN("096619926626").IdPresentacionArticulo;
            Assert.AreEqual(resultado, 1);
        }
    }
#endif
}
