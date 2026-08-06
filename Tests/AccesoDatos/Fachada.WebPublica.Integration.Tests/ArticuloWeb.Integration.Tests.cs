// -----------------------------------------------------------------------
// <copyright file="ArticuloWeb.Integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.Integration.TablasMaestras
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class ArticuloWebIntegrationTests
    {
        [TestMethod]
        public void ListarPorIdsCategorias_ConsultaListaDeArticulosDeMultiplesCategorias_RetornaSoloLosIdsVariosElementos()
        {
            Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();
            System.Collections.Generic.List<double> ListaIdsCategorias = new System.Collections.Generic.List<double> { 30, 21, 39 };
            System.Collections.ObjectModel.ReadOnlyCollection<double> ListaSoloLecturaIdsCategorias = new System.Collections.ObjectModel.ReadOnlyCollection<double>(ListaIdsCategorias);
            int resultado = FachadaArticulo.ListarPorIdsCategorias(ListaSoloLecturaIdsCategorias).Count;
            Assert.IsTrue(resultado > 0);
        }

        [TestMethod]
        public void ListarPorIdsCategorias_ConsultaListaDeArticulosDeMultiplesCategoriasInexistentes_RetornaSoloLosIdsVariosElementos()
        {
            Fachada.WebPublica.Articulo FachadaArticulo = new Fachada.WebPublica.Articulo();
            System.Collections.Generic.List<double> ListaIdsCategorias = new System.Collections.Generic.List<double> { 100000000, -100000000 };
            System.Collections.ObjectModel.ReadOnlyCollection<double> ListaSoloLecturaIdsCategorias = new System.Collections.ObjectModel.ReadOnlyCollection<double>(ListaIdsCategorias);
            int resultado = FachadaArticulo.ListarPorIdsCategorias(ListaSoloLecturaIdsCategorias).Count;
            Assert.IsTrue(resultado == 0);
        }
    } 
#endif
}
