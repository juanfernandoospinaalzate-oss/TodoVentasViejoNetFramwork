// -----------------------------------------------------------------------
// <copyright file="CategoriaWeb.Integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.WebPublica.Integration.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class CategoriaWebIntegrationTests
    {
        [TestMethod]
        public void ListarCategoriasUsadas_ConsultarLasCategoriasUsadas_RetornaListaDeCategoriasUsadasUnSoloElemento()
        {
            Fachada.WebPublica.Categoria FachadaCategoria = new Fachada.WebPublica.Categoria();
            int resultado = FachadaCategoria.ListarCategoriasUsadas().Count;
            Assert.AreEqual(resultado, 1);
        }
    } 
#endif
}
