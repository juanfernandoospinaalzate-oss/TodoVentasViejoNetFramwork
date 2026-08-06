//-----------------------------------------------------------------------
// <copyright file="Albaran.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    using System;

    /// <summary>
    /// Representa un documento de venta que no es una factura
    /// </summary>
    public class Albaran
    {
        public int IdAlbaran { get; set; }

        public int NroFactura { get; set; }

        public int IdCliente { get; set; }

        public int DocCliente { get; set; }

        public string NombreCliente { get; set; }

        public string ApellidoCliente { get; set; }

        public string TelefonoClienteUno { get; set; }

        public string TelefonoClienteDos { get; set; }

        public string EmailCliente { get; set; }

        public string ContrasenaCliente { get; set; }

        public string NombreDestinatario { get; set; }

        public string DireccionEnvioDestinatario { get; set; }

        public string TelefonoDestinatario { get; set; }

        public string NombrePaisDestinatario { get; set; }

        public string NombreDepartamentoDestinatario { get; set; }

        public string NombreCiudadDestinatario { get; set; }

        public DateTime Fecha { get; set; }

        public int CodigoReferenciaPayU { get; set; }

        public string MedioDEPago { get; set; }

        public double TotalVenta { get; set; }

        public double TotalCosto { get; set; }

        public string NroGuia { get; set; }

        public int CostoFlete { get; set; }

        public bool Anulado { get; set; }

        public string IdPreferencia { get; set; }

        public string EstadoDeLaVenta { get; set; }
    }
}
