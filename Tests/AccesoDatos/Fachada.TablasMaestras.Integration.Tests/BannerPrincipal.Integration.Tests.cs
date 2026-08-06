using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fachada.Integration.TablasMaestras
{
#if Pruebas
    [TestClass]
    public class BannerPrincipalIntegrationTests
    {
        Fachada.TablasMaestras.BannerPrincipal FachadaBanner = null;
        Entidades.BannerPrincipal ObjBanner = null;

        [TestInitialize]
        public void SetUp()
        {
            FachadaBanner = new Fachada.TablasMaestras.BannerPrincipal();
            ObjBanner = new Entidades.BannerPrincipal();

            ObjBanner.BigBanner1 = "Imagen BigBanner 1";
            ObjBanner.BigBanner2 = "Imagen BigBanner 2";
            ObjBanner.BigBanner3 = "Imagen BigBanner 3";
            ObjBanner.BigBanner4 = "Imagen BigBanner 4";
            ObjBanner.BigBanner5 = "Imagen BigBanner 4";
            ObjBanner.SmallBanner1 = "Imagen Small Banner 1";
            ObjBanner.SmallBanner2 = "Imagen Small Banner 2";
            ObjBanner.SmallBanner3 = "Imagen Small Banner 3";
            ObjBanner.SmallBanner4 = "Imagen Small Banner 4";
            ObjBanner.SmallBanner5 = "Imagen Small Banner 5";
            ObjBanner.VideoDataSource = Entidades.Enumeraciones.BannerPrincipalVideoDataSource.youtube;
            ObjBanner.VideoDataId = "asdfg";
            ObjBanner.VideoImagenMiniatura = "lkjhlg";
        }

        [TestMethod]
        public void ActualizarBanner()
        {
            Entidades.ResultadoTransaccion Resultado = this.FachadaBanner.Actualizar(this.ObjBanner);
            Assert.AreEqual(1, Resultado.RegistrosAfectados);
        }

        [TestMethod]
        public void ConsultarBanner()
        {
            Entidades.BannerPrincipal Resultado = this.FachadaBanner.Consultar();
            Assert.IsNotNull(Resultado);
        }

        [TestMethod]
        public void InsertarBanner()
        {
            Entidades.ResultadoTransaccion Resultado = this.FachadaBanner.Insertar(this.ObjBanner);
            Assert.AreEqual(1, Resultado.RegistrosAfectados);
        }
    }
#endif
}
