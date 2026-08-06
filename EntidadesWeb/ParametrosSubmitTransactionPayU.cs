//-----------------------------------------------------------------------
// <copyright file="ParametrosSubmitTransactionPayU.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    using System.Collections.Generic;

    public class ParametrosSubmitTransactionPayU
    {
        public int IdUsuario { get; set; }

        private EntidadesWeb.Enumeraciones.MedioPago MediosPago = new Enumeraciones.MedioPago();
        public EntidadesWeb.Enumeraciones.MedioPago MediosDePago
        {
            get 
            {
                return this.MediosPago;
            }
            set
            {
                this.MediosPago = value;
            }        
        }

        public string NroTarjetaCredito { get; set; }

        public string CodigoSeguridadTarjetaCredito { get; set; }

        public string MesVencimientoTarjetaCredito { get; set; }

        public string AnioVencimientoTarjetaCredito { get; set; }

        public string NombreTarjetaCredito { get; set; }

        public string TipoDePersona { get; set; }

        public string TipoDeDocumentoDeIdentificacion { get; set; }

        public string NombrePagador { get; set; }

        public string CorreoElectronicoPagador { get; set; }

        public string TelefonoPagador { get; set; }

        public string IdentificacionPagador { get; set; }

        public string DireccionPrincipal { get; set; }
        
        // public string DireccionSecundaria { get; set; }

        private EntidadesWeb.Ciudad EntidadCiudad = new EntidadesWeb.Ciudad();
        public EntidadesWeb.Ciudad Ciudad
        {
            get
            {
                return this.EntidadCiudad;
            }
            set
            {
                this.EntidadCiudad = value;
            }
        }

        private EntidadesWeb.Departamento EntidadDepartamento = new EntidadesWeb.Departamento();
        public EntidadesWeb.Departamento Departamento
        {
            get
            {
                return this.EntidadDepartamento;
            }
            set
            {
                this.EntidadDepartamento = value;
            }
        }


        private EntidadesWeb.Pais EntidadPais = new EntidadesWeb.Pais();
        public EntidadesWeb.Pais Pais
        {
            get
            {
                return this.EntidadPais;
            }
            set
            {
                this.EntidadPais = value;
            }
        }

        public string CodigoPostal { get; set; }


        // Parametros buyer del archivo XML
        public string NombreComprador { get; set; }

        public string CorreoElectronicoComprador { get; set; }

        public string TelefonoComprador { get; set; }

        public string IdentificacionComprador { get; set; }

        // Parametros direccion de envio del archivo XML
        private EntidadesWeb.Direccion EntidadDireccion = new EntidadesWeb.Direccion();
        public EntidadesWeb.Direccion DireccionDeEnvio
        {
            get
            {
                return this.EntidadDireccion;
            }
            set
            {
                this.EntidadDireccion = value;
            }
        }

        public string CodigoPostalComprador { get; set; }

        private EntidadesWeb.Banco banco = new EntidadesWeb.Banco();
        public EntidadesWeb.Banco Banco 
        {
            get
            {
                return this.banco;
            }
            set
            {
                this.banco = value;
            }
        }

        public string SessionIdDispositivo { get; set; }


        // PARAMETROS REGISTRO NUEVO DE CLIENTE
        public string DocumentoCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TelefonoUno { get; set; }
        public string TelefonoDos { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string NombreDestinatario { get; set; }
        public string DireccionEnvio { get; set; }
        public string TelefonoDestinatario { get; set; }


        // LISTA COMO PARAMETRO

        public List<EntidadesWeb.ItemCarrito> ListaCarritoModoInvitado { get; set; }

        
    }
}
