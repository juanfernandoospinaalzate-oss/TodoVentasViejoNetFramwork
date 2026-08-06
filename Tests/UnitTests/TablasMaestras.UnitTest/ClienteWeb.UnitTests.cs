using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TablasMaestras.UnitTest
{
#if Pruebas
    [TestClass]
    public class ClienteWebUnitTests
    {
        EntidadesWeb.Cliente Cliente = null;
        EntidadesWeb.Direccion Direccion = null;
        Validacion.WebPublica.Cliente ValidacionCliente = null;

        [TestInitialize]
        public void SetUp()
        {
            this.Cliente = new EntidadesWeb.Cliente();
            this.Direccion = new EntidadesWeb.Direccion();
            this.ValidacionCliente = new Validacion.WebPublica.Cliente();

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
        public void Insertar_ClienteFormatoDeEmailNoValidoSinArroba_RetornaRegistrosAfectadosCero()
        {
            this.Cliente.Email = "usuariodominio.com";
            int resultado = this.ValidacionCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_ClienteFormatoDeEmailNoValidoSinPunto_RetornaRegistrosAfectadosCero()
        {
            this.Cliente.Email = "usuario@dominiocom";
            int resultado = this.ValidacionCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_ClienteFormatoDeEmailNoValidoSinUsuario_RetornaRegistrosAfectadosCero()
        {
            this.Cliente.Email = "@dominio.com";
            int resultado = this.ValidacionCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_ClienteFormatoDeEmailNoValidoSinDominio_RetornaRegistrosAfectadosCero()
        {
            this.Cliente.Email = "usuario@.com";
            int resultado = this.ValidacionCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_ClienteFormatoDeEmailNoValidoSinExtencion_RetornaRegistrosAfectadosCero()
        {
            this.Cliente.Email = "usuario@dominio.";
            int resultado = this.ValidacionCliente.Insertar(this.Cliente, this.Direccion).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }
    } 
#endif
}
