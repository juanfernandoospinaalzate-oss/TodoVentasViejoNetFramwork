//-----------------------------------------------------------------------
// <copyright file="Kardex.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    using System;

    /// <summary>
    /// Entidad correspondiente a un registro en el kardex de la base de datos
    /// </summary>
    public class Kardex
    {
        /// <summary>
        /// identificación única de la presentación del artículo
        /// </summary>
        public int IdPresentacionArticulo { get; set; }

        /// <summary>
        /// Fecha y hora del cambio en la cantidad del inventario
        /// </summary>
        public DateTime Fecha { get; set; }
        
        /// <summary>
        /// Nombre de la presentación del artículo
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Cantidad de entrada, siempre positiva, si se diligencia entonces la cantidad de salida se debe hacer cero
        /// </summary>
        public int CantidadEntrada { get; set; }

        /// <summary>
        /// Cantidad de salida, siempre positiva, si se diligencia entonces la cantidad de entrada se debe hacer cero
        /// </summary>
        public int CantidadSalida { get; set; }

        /// <summary>
        /// Precio de venta de por unidad
        /// </summary>
        public double PrecioUnitario { get; set; }
        
        /// <summary>
        /// Costo de compra por unidad
        /// </summary>
        public double CostoUnitario { get; set; }
        
        /// <summary>
        /// Cantidad existente en inventario
        /// </summary>
        public int TotalExistencias { get; set; }
        
        /// <summary>
        /// Precio resultado del precio por unidad multiplicado por el total de existencias en inventario
        /// </summary>
        public double PrecioTotal { get; set; }
        
        /// <summary>
        /// Costo total resultado del costo por unidad multiplicado por el total de existencias en inventario
        /// </summary>
        public double CostoTotal { get; set; }

        /// <summary>
        /// Texto explicativo del registro en el kardex
        /// </summary>
        public string Detalle { get; set; }
    }
}
