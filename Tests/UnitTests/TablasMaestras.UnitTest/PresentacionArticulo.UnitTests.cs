// -----------------------------------------------------------------------
// <copyright file="PresentacioinArticulo.UnitTests.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace TablasMaestras.UnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Pruebas
    [TestClass]
    public class PresentacionArticuloUnitTests
    {
        private Entidades.PresentacionArticulo Presentacion = null;
        private Entidades.Kardex Registrokardex = null;
        private Validacion.TablasMaestras.PresentacionArticulo ValidacionPresentaacion = null;

        [TestInitialize]
        public void SetUp()
        {
            this.ValidacionPresentaacion = new Validacion.TablasMaestras.PresentacionArticulo();
            this.Presentacion = new Entidades.PresentacionArticulo()
            {
                Activo = true,
                Articulo = new Entidades.Articulo() { IdArticulo = 1 },
                CodigoEAN = "096619926626",
                Color = new Entidades.Color() { IdColor = 1 },
                CostoArticulo = 0,
                DescripcionBreve = "Aceite de pescado bla bla bla",
                EnLinea = true,
                Existencias = 0,
                Fecha = DateTime.Now,
                FechaFinalDescuento = DateTime.Now,
                FechaInicioDescuento = DateTime.Now,
                FechaProximoVencimiento = DateTime.Now,
                IdPresentacionArticulo = 1,
                Imagen1 = new byte[] { 1, 2, 3 },
                Imagen2 = null,
                Imagen3 = null,
                Imagen4 = null,
                Imagen5 = null,
                Imagen6 = null,
                Nombre = "Fish Oil Omega 3 Kirkland",
                Precio = 164000,
                PreOrden = true,
                Sabor = new Entidades.Sabor() { IdSabor = 1 },
                Talla = new Entidades.Talla() { IdTalla = 1 },
                UnidadLongitud = new Entidades.UnidadLongitud() { IdUnidadLongitud = 1 },
                UnidadMasa = new Entidades.UnidadMasa() { IdUnidadMasa = 1 },
                UnidadPresentacion = new Entidades.UnidadPresentacion() { IdUnidadPresentacion = 4 },
                UnidadVolumen = new Entidades.UnidadVolumen() { IdUnidadVolumen = 1 },
                UsarDescuento = true,
                UsarFechaProximoVencimiento = false,
                UsarPorcentajeDescuento = false,
                UsarValorFijoDescuento = false,
                ValorFijoDescuento = 0,
                ValorPorcentajeDescuento = 0,
                VlrContenidoVolumetrico = 0,
                VlrUnidadLongitud = 0,
                VlrUnidadMasa = 0,
                VlrUnidadPresentacion = 0,
                VlrUnidadVolumenAncho = 0,
                VlrUnidadVolumenLargo = 0,
                VlrUnidadVolumenProfundidad = 0
            };

            this.Registrokardex = new Entidades.Kardex()
            {
                IdPresentacionArticulo = 1,
                CantidadEntrada = 0,
                CantidadSalida = 0,
                CostoUnitario = 5000,
                PrecioUnitario = 15000,
                TotalExistencias = 2,
                CostoTotal = 10000,
                PrecioTotal = 30000,
                Detalle = "Prueba Atomatizada",
                Fecha = DateTime.Now,
                Nombre = "Artículo de Prueba Automatizada"
            };
        }

        #region "Insertar"
        [TestMethod]
        public void Insertar_UsarDescuentoAmbosDescuentosEstanActivos_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = true;
            this.Presentacion.UsarValorFijoDescuento = true;
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_UsarDescuentoAmbosDescuentosEstanInactivos_RetornaCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = false;
            this.Presentacion.UsarValorFijoDescuento = false;
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_UsarPorcentajeDescuentoPorcentajeMayorCeroValorFijoNoEsCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = true;
            this.Presentacion.ValorPorcentajeDescuento = 1; // El porcentaje debe ser mayor a cero para insertar el registro
            this.Presentacion.ValorFijoDescuento = 1; // Este valor debe ser cero para poder insertar el registro
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_UsarPorcentajeDescuentoPorcentajeEsCeroValorFijoEsCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = true;
            this.Presentacion.ValorPorcentajeDescuento = 0; // Este valor debe ser diferente de cero para poder insertar el registro
            this.Presentacion.ValorFijoDescuento = 0;
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_UsarVaorFijoDescuentoValorFijoMayorCeroPorcentajeDiferenteCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarValorFijoDescuento = true;
            this.Presentacion.ValorFijoDescuento = 1; // El valor fijo debe ser mayor a cero
            this.Presentacion.ValorPorcentajeDescuento = 1; // Este valor tiene que ser cero para poder insertar el registro
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_UsarVaorFijoDescuentoValorFijoEsCeroPorcentajeDiferenteCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarValorFijoDescuento = true;
            this.Presentacion.ValorFijoDescuento = 0; // Este valor tiene que ser positivo para poder insertar el registro
            this.Presentacion.ValorPorcentajeDescuento = 0;
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_FechaInicioDescuentoNoEsMenorFechaFinalDescuento_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = true;
            this.Presentacion.FechaInicioDescuento = DateTime.Now.AddDays(1); // Eldescuento inicia mañana
            this.Presentacion.FechaFinalDescuento = DateTime.Now.AddDays(-1); // Pero finaliza ayer
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_AlgunaDeLasFechasDescuentoEsSonDelPasadoLejano_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.FechaInicioDescuento = new DateTime(2020, 1, 1);
            this.Presentacion.FechaFinalDescuento = new DateTime(2020, 1, 1);
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_CodigoEanTieneMasDeTreintaCaracteres_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.CodigoEAN = "012345678901234567890123456789X";
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Insertar_NombrePresentacionArticuloTieneMasDeCienCaracteres_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.Nombre = "Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland";
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }
        #endregion

        #region "Actualizar"
        [TestMethod]
        public void Actualizar_UsarDescuentoAmbosDescuentosEstanActivos_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = true;
            this.Presentacion.UsarValorFijoDescuento = true;
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_UsarDescuentoAmbosDescuentosEstanInactivos_RetornaCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = false;
            this.Presentacion.UsarValorFijoDescuento = false;
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_UsarPorcentajeDescuentoPorcentajeMayorCeroValorFijoNoEsCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = true;
            this.Presentacion.ValorPorcentajeDescuento = 1; // El porcentaje debe ser mayor a cero para insertar el registro
            this.Presentacion.ValorFijoDescuento = 1; // Este valor debe ser cero para poder insertar el registro
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_UsarPorcentajeDescuentoPorcentajeEsCeroValorFijoEsCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarPorcentajeDescuento = true;
            this.Presentacion.ValorPorcentajeDescuento = 0; // Este valor debe ser diferente de cero para poder insertar el registro
            this.Presentacion.ValorFijoDescuento = 0;
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_UsarVaorFijoDescuentoValorFijoMayorCeroPorcentajeDiferenteCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarValorFijoDescuento = true;
            this.Presentacion.ValorFijoDescuento = 1; // El valor fijo debe ser mayor a cero
            this.Presentacion.ValorPorcentajeDescuento = 1; // Este valor tiene que ser cero para poder insertar el registro
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_UsarVaorFijoDescuentoValorFijoEsCeroPorcentajeDiferenteCero_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarValorFijoDescuento = true;
            this.Presentacion.ValorFijoDescuento = 0; // Este valor tiene que ser positivo para poder insertar el registro
            this.Presentacion.ValorPorcentajeDescuento = 0;
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_FechaInicioDescuentoNoEsMenorFechaFinalDescuento_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = true;
            this.Presentacion.FechaInicioDescuento = DateTime.Now.AddDays(1); // Eldescuento inicia mañana
            this.Presentacion.FechaFinalDescuento = DateTime.Now.AddDays(-1); // Pero finaliza ayer
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_AlgunaDeLasFechasDescuentoEsSonDelPasadoLejano_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.FechaInicioDescuento = new DateTime(2020, 1, 1);
            this.Presentacion.FechaFinalDescuento = new DateTime(2020, 1, 1);
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_CodigoEanTieneMasDeTreintaCaracteres_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.CodigoEAN = "012345678901234567890123456789X";
            int resultado = this.ValidacionPresentaacion.Actualizar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void Actualizar_NombrePresentacionArticuloTieneMasDeCienCaracteres_RetornaRegistrosAfectadosCero()
        {
            this.Presentacion.UsarDescuento = false;
            this.Presentacion.Nombre = "Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland Fish Oil Omega 3 Kirkland";
            int resultado = this.ValidacionPresentaacion.Insertar(this.Presentacion, this.Registrokardex).RegistrosAfectados;
            Assert.AreEqual(resultado, 0);
        }
        #endregion
    }
#endif
}
