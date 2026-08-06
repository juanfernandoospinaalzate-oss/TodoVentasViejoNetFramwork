using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fachada.Integration.TablasMaestras
{
#if Pruebas
    [TestClass]
    public class MarcaIntegrationTests
    {
        Entidades.Marca Marca = null;
        Fachada.TablasMaestras.Marca FachadaMarca = null;

        [TestInitialize]
        public void SetUp()
        {
            this.Marca = new Entidades.Marca();
            this.FachadaMarca = new Fachada.TablasMaestras.Marca();
        }

        [TestMethod]
        public void Insertar_MarcaNombreYaExistente_RetornaRegistrosAfectadosCero()
        {
            this.Marca.Nombre = "Aeropostale";
            int resultado = this.FachadaMarca.Insertar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_MarcaNombreNoExistente_RetornaRegistrosAfectadosUno()
        {
            this.Marca.Nombre = "Nueva Marca";
            int resultado = this.FachadaMarca.Insertar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void ListarPorNombre_MarcaNombreNoExiste_RetornaIdMarcaCero()
        {
            int resultado = this.FachadaMarca.ListarPorNombre("Marca que no existe").Count;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void ListarPorNombre_MarcaNombrYaExisteSinDuplicados_RetornaCountIdMarcaUno()
        {
            int resultado = this.FachadaMarca.ListarPorNombre("Adidas").Count;
            Assert.AreNotEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_MarcaNombreYaExistenteConDiferenteIdCreandoDuplicado_RetornaRegistrosAfectadosCero()
        {
            this.Marca.IdMarca = 1; // Pertenere a "Sin Marca"
            this.Marca.Nombre = "Aeropostale";
            int resultado = this.FachadaMarca.Actualizar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_MarcaCambioDeNombreIdNoExistente_RetornaRegistrosAfectadosCero()
        {
            this.Marca.IdMarca = 0;
            this.Marca.Nombre = "Aeropostale";
            int resultaado = this.FachadaMarca.Actualizar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultaado, 0);
        }

        [TestMethod]
        public void Actualizar_MarcaCambioDeNombre_RetornaRegistrosAfectadosUno()
        {
            this.Marca.IdMarca = 3;
            this.Marca.Nombre = "Aeropostale Mod";
            int resultaado = this.FachadaMarca.Actualizar(this.Marca).RegistrosAfectados;
            Assert.AreEqual(resultaado, 1);
        }

        [TestMethod]
        public void ListarPorId_MarcaNoExiste_RetornaCountIdMarcaCero()
        {
            this.Marca.IdMarca = 0;
            int resultado = this.FachadaMarca.ListarPorId(this.Marca.IdMarca).Count;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void ListarPorId_MarcaExistente_RetornaCountIdMarcaUno()
        {
            this.Marca.IdMarca = 1; // Pertenere a "Sin Marca"
            int resultado = this.FachadaMarca.ListarPorId(this.Marca.IdMarca).Count;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void EliminarPorId_MarcaNoExistente_RetornaRegistrosAfectadosCero()
        {
            this.Marca.IdMarca = 0; 
            int resultado = this.FachadaMarca.Eliminar(this.Marca.IdMarca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void EliminarPorId_MarcaTieneRegistrosAsociados_RetornaRegistrosAfectadosCero()
        {
            this.Marca.IdMarca = 1;
            int resultado = this.FachadaMarca.Eliminar(this.Marca.IdMarca).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        // VerificarRelacionArticulo
        [TestMethod]
        public void VerificarRelacionArticulo_RelacionNoExistente_RetornaFalse()
        {
            this.Marca.IdMarca = 0;
            bool resultado = this.FachadaMarca.VerificarRelacionArticulo(Marca.IdMarca);
            Assert.AreEqual(resultado, false);
        }

        [TestMethod]
        public void VerificarRelacionArticulo_RelacionExistente_RetornaTrue()
        {
            this.Marca.IdMarca = 1;
            bool resultado = this.FachadaMarca.VerificarRelacionArticulo(Marca.IdMarca);
            Assert.AreEqual(resultado, true);
        }
    }
#endif
}
