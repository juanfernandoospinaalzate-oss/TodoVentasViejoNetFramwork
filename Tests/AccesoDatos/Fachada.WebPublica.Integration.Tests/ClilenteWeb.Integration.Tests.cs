 using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fachada.WebPublica.Integration.Tests
{
#if Pruebas
    [TestClass]
    public class ClilenteWebIntegrationTests
    {
        EntidadesWeb.Cliente Cliente = null;
        EntidadesWeb.Direccion Direccion = null;
        Fachada.WebPublica.Cliente FachadaCliente = null;

        [TestInitialize]
        public void SetUp()
        {
            this.Cliente = new EntidadesWeb.Cliente();
            this.Direccion = new EntidadesWeb.Direccion();
            this.FachadaCliente = new Fachada.WebPublica.Cliente();

            this.Cliente.Nombre = "Juan Integration Test";
            this.Cliente.Apellido = "Ospina Integration Test";
            this.Cliente.Telefono1 = "12345 Integration Test";
            this.Cliente.Telefono2 = "65490 Integration Test";
            this.Cliente.Email = "usuario@dominio.com";
            this.Cliente.Contrasena = "12345";
            this.Cliente.ConfirmarContrasena = "12345";
            this.Cliente.DocCliente = 25721317;

            this.Direccion.NombreDestinatario = this.Cliente.Nombre + " " + this.Cliente.Apellido;
            this.Direccion.DireccionEnvio = "Calle 21 Integration Test";
            this.Direccion.Telefono = this.Cliente.Telefono1;
            this.Direccion.Pais.IdPais = 52;
            this.Direccion.Departamento.IdDepartamento = 2;
            this.Direccion.Ciudad.IdCiudad = 82;
        }

        [TestMethod]
        public void Insertar_Cliente_RetornaNroRegistrosAfectadosDos()
        {
            int resultado = this.FachadaCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 2);
        }

        [TestMethod]
        public void Insertar_ClienteDocumentoIdentificacionYaExiste_RetornaNroRegistrosAfectadosCero()
        {
            this.Cliente.DocCliente = 71312752;
            int resultado = this.FachadaCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_ClienteEmailYaExiste_RetornaNroRegistrosAfectadosCero()
        {
            this.Cliente.Email = "juan_fernando_ospina@hotmail.com";
            int resultado = this.FachadaCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }
    } 
#endif
}
