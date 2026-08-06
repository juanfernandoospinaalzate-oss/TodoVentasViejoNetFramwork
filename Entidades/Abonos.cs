//-----------------------------------------------------------------------
// <copyright file="Abonos.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    using System;

    /// <summary>
    /// Abono en un albarán
    /// </summary>
    public class Abonos
    {
        /// <summary>
        /// Id Autonumérico del abono
        /// </summary>
        public int IdAbono { get; set; }

        /// <summary>
        /// Id Autonumérico del albarán
        /// </summary>
        public int IdAlbaran { get; set; }

        /// <summary>
        /// Cantidad por el cual es hecho el abono
        /// </summary>
        public double ValorAbono { get; set; }

        /// <summary>
        /// Momento en que es registrado el abono
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Id del medio de pago utilizado para hacer el abono
        /// </summary>
        public string MedioDePago { get; set; }

        /// <summary>
        /// Número de factura a la que se aplica el abono
        /// </summary>
        public int NroFactura { get; set; }

        /// <summary>
        /// Identificación (Id) del cliente en la base de datos
        /// </summary>
        public string NombreCompletoCliente { get; set; }
    }
}
