// -----------------------------------------------------------------------
// <copyright file="Direccion.Integration.Tests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.Integration.TablasMaestras
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class DireccionIntegrationTests
    {
        [TestMethod]
        public void ConsultarDireccionPorId_ConsultarLasDireccionesdeUnClienteExistente_RegistrosEncontradosCantidadSuperiorAUno()
        {
            Fachada.TablasMaestras.Direccion direccion = new Fachada.TablasMaestras.Direccion();
            int resultado = direccion.ConsultarDireccionPorId(1).Count;
            Assert.IsTrue(resultado > 0);
        }

        [TestMethod]
        public void ConsultarDireccionPorId_ConsultarLasDireccionesdeUnClienteNoExistente_RegistrosEncontradosCero()
        {
            Fachada.TablasMaestras.Direccion direccion = new Fachada.TablasMaestras.Direccion();
            int resultado = direccion.ConsultarDireccionPorId(-1).Count;
            Assert.AreEqual(resultado, 0);
        }
    } 
#endif
}