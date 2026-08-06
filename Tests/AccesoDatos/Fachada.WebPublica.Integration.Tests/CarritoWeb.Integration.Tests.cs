using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fachada.WebPublica.Integration.Tests
{
#if Pruebas
    [TestClass]
    public class CarritoWebIntegrationTests
    {
        Fachada.WebPublica.Carrito FachadaCarrito = null;
        EntidadesWeb.ItemCarrito ItemCarrito = null;
        EntidadesWeb.ItemCarrito ItemCarrito2 = null;
        System.Collections.Generic.List<EntidadesWeb.ItemCarrito> ListaItemsCarrito = null;
        EntidadesWeb.Cliente Cliente = null;
        EntidadesWeb.Direccion Direccion = null;

        [TestInitialize]
        public void SetUp()
        {
            this.FachadaCarrito = new Fachada.WebPublica.Carrito();

            this.ItemCarrito = new EntidadesWeb.ItemCarrito();
            this.ItemCarrito.IdItemCarrito = 8160;
            this.ItemCarrito.IdUsuario = 3064;
            this.ItemCarrito.IdPrestacionArticulo = 1;
            this.ItemCarrito.Cantidad = 1;
            this.ItemCarrito.Nombre = "Omega 3 Kirkland 400 Capsulas Blandas 1.000 mg";
            this.ItemCarrito.Precio = 106000;
            
            this.ItemCarrito2 = new EntidadesWeb.ItemCarrito();
            this.ItemCarrito2.IdItemCarrito = 3116;
            this.ItemCarrito2.IdUsuario = this.ItemCarrito.IdUsuario;
            this.ItemCarrito2.IdPrestacionArticulo = 19383;
            this.ItemCarrito2.Cantidad = 1;
            this.ItemCarrito2.Nombre = "Garnier Fructis Acondicionador Sandia 50% mas contenido";
            this.ItemCarrito2.Precio = 80000;

            this.Cliente = new EntidadesWeb.Cliente();
            this.Cliente.IdCliente = this.ItemCarrito.IdUsuario;
            this.Cliente.DocCliente = 71312752;
            this.Cliente.Apellido = "Ospina Alzate";
            this.Cliente.Nombre = "Juan Fernando";
            this.Cliente.Telefono1 = "3014588062";
            this.Cliente.Telefono2 = "301 458 80 62";
            this.Cliente.Email = "juan_fernando_ospina@hotmail.com";
            this.Cliente.ConfirmarContrasena = string.Empty;
            this.Cliente.Contrasena = string.Empty;

            this.Direccion = new EntidadesWeb.Direccion();
            this.Direccion.IdDireccion = 4058;
            this.Direccion.Pais.IdPais = 0;
            this.Direccion.Pais.Nombre = "Colombia";
            this.Direccion.Departamento.Pais = this.Direccion.Pais;
            this.Direccion.Departamento.IdDepartamento = 0;
            this.Direccion.Departamento.Nombre = "Antioquia";
            this.Direccion.Ciudad.Departamento = this.Direccion.Departamento;
            this.Direccion.Ciudad.IdCiudad = 0;
            this.Direccion.Ciudad.Nombre = "Abriaquí";
            this.Direccion.DireccionEnvio = "arrera 70 # 30A 87 piso 2";
            this.Direccion.IdCliente = this.Cliente.IdCliente;
            this.Direccion.NombreDestinatario = "Juanfer";
            this.Direccion.Telefono = "3511322";

            this.ListaItemsCarrito = new System.Collections.Generic.List<EntidadesWeb.ItemCarrito>();
            this.ListaItemsCarrito.Add(this.ItemCarrito);
            this.ListaItemsCarrito.Add(this.ItemCarrito2);
        }

        [TestMethod]
        public void Eliminar_EliminarUnItemCarrito_RetornaRegistrosAfectadosUno()
        {
            int resultado = this.FachadaCarrito.Eliminar(this.ItemCarrito.IdItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void Eliminar_EliminarUnItemCarritoNoExistente_RetornaRegistrosAfectadosCero()
        {
            this.ItemCarrito.IdItemCarrito = 0;
            int resultado = this.FachadaCarrito.Eliminar(this.ItemCarrito.IdItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_ActualizarCantidadEnItemCarritoExistente_RetornaRegistrosAfectadosUno()
        {
            int resultado = this.FachadaCarrito.Actualizar(this.ItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void Actualizar_ActualizarCantidadEnItemCarritoInexistente_RetornaRegistrosAfectadosCero()
        {
            this.ItemCarrito.IdItemCarrito = 0;
            int resultado = this.FachadaCarrito.Actualizar(this.ItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Listar_ListaItemsDeCarritoExistente_RetornaRegistrosRetornadosCantidadPositiva()
        {
            int resultado = this.FachadaCarrito.Listar(this.ItemCarrito.IdUsuario).Count;
            Assert.IsTrue(resultado > 0);
        }

        [TestMethod]
        public void Listar_ListaItemsDeCarritoInexistente_RetornaRegistrosRetornadosCero()
        {
            this.ItemCarrito.IdUsuario = 0;
            int resultado = this.FachadaCarrito.Listar(this.ItemCarrito.IdUsuario).Count;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_ActualizaRegistroEnElCarritoSumandoCantidades_RetornaRegistrosAfectadosUno()
        {
            int resultado = this.FachadaCarrito.Insertar(this.ItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void Insertar_NuevoRegistroEnElCarrito_RetornaRegistrosAfectadosUno()
        {
            this.ItemCarrito.IdPrestacionArticulo = 2; // Triple Omega
            int resultado = this.FachadaCarrito.Insertar(this.ItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 1);
        }

        [TestMethod]
        public void Insertar_NuevoRegistroEnElCarritoUsuarioNoExiste_RetornaRegistrosAfectadosCero()
        {
            this.ItemCarrito.IdUsuario = 0;
            int resultado = this.FachadaCarrito.Insertar(this.ItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_NuevoRegistroEnElCarritoPresentacionArticuloExiste_RetornaRegistrosAfectadosCero()
        {
            this.ItemCarrito.IdPrestacionArticulo = 0;
            int resultado = this.FachadaCarrito.Insertar(this.ItemCarrito).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void ConsultarPorIdPresentacionArticulo_RecuperaItemCarritoExistente_RetornaItemCarritoDiferenteDeNull()
        {
            EntidadesWeb.ItemCarrito resultado = this.FachadaCarrito.ConsultarPorIdPresentacionArticulo(this.ItemCarrito.IdPrestacionArticulo, this.ItemCarrito.IdUsuario);
            Assert.IsTrue(resultado != null);
        }

        [TestMethod]
        public void ConsultarPorIdPresentacionArticulo_RecuperaItemCarritoPresentacionArticuloNoExiste_RetornaItemCarritoNull()
        {
            EntidadesWeb.ItemCarrito resultado = this.FachadaCarrito.ConsultarPorIdPresentacionArticulo(0, this.ItemCarrito.IdUsuario);
            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void ConsultarPorIdPresentacionArticulo_RecuperaItemCarritoUsuarioNoExiste_RetornaItemCarritoNull()
        {
            EntidadesWeb.ItemCarrito resultado = this.FachadaCarrito.ConsultarPorIdPresentacionArticulo(this.ItemCarrito.IdPrestacionArticulo, 0);
            Assert.IsTrue(resultado == null);
        }

        [TestMethod]
        public void TotalPorIdUsuario_TotalizarIdUsuarioExistente_RetornaTotalEnCarrito()
        {
            double resultado = this.FachadaCarrito.TotalPorIdUsuario(this.ItemCarrito.IdUsuario);
            Assert.IsTrue(resultado > 0);
        }

        [TestMethod]
        public void TotalPorIdUsuario_TotalizarIdUsuarioNoExistente_RetornaTotalEnCarritoCero()
        {
            double resultado = this.FachadaCarrito.TotalPorIdUsuario(0);
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void GenerarPreferenciaPago_UtilizandoMercadopago_RetornaLinkDePago()
        {
            string resultado = FachadaCarrito.GenerarPreferenciaPago(this.ListaItemsCarrito, this.Cliente, this.Direccion, EntidadesWeb.Enumeraciones.MedioPago.MercadoPago, 0, string.Empty);
            Assert.IsTrue(resultado.Contains("https://www.mercadopago.com.co/checkout/v1/redirect?pref_id="));
        }
    }
#endif
}
