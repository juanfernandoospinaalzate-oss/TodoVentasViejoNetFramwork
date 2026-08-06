using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fachada.WebPublica.Integration.Tests
{
#if Pruebas
    [TestClass]
    public class BannerPrincipalIntegrationTests
    {
        Fachada.WebPublica.BannerPrincipal FachadaBannerPrincipal = null;

        [TestInitialize]
        public void SetUp()
        {
            FachadaBannerPrincipal = new WebPublica.BannerPrincipal();
        }

        [TestMethod]
        public void ConsultarBanner()
        {
            EntidadesWeb.BannerPrincipal Resultado = FachadaBannerPrincipal.Consultar();
            Assert.IsNotNull(Resultado);
        }
    } 
#endif
}
