using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fachada.Integration.TablasMaestras
{
#if Pruebas
    [TestClass]
    public class ArticuloIntegrationTests
    {
        [TestMethod]
        public void Eliminar_EliminarUnArticuloSinPresentacionesDeArticulosAsociados_RetornaRegistrosAfectadosUno()
        {
            // Identificación 6369, Hot Wheels Auto Lavado
            Fachada.TablasMaestras.Articulo FachadaArticulo = new Fachada.TablasMaestras.Articulo();
            int resultado = FachadaArticulo.Eliminar(6369).RegistrosAfectados;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void Eliminar_EliminarUnArticuloConPresentacionesDeArticulosAsociados_RetornaRegistrosAfectadosCero()
        {
            // Identificación 1, Omega 3 Kirkland 1000 mg 400 Capsulas Blandas
            Fachada.TablasMaestras.Articulo FachadaArticulo = new Fachada.TablasMaestras.Articulo();
            int resultado = FachadaArticulo.Eliminar(1).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }
    } 
#endif
}
