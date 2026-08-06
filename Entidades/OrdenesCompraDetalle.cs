//-----------------------------------------------------------------------
// <copyright file="OrdenesCompraDetalle.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class OrdenesCompraDetalle
    {
        public string NombreMarca { get; set; }

        public string Titulo { get; set; }

        public string NombreUnidadVolumen { get; set; }

        public string NombreUnidadMasa { get; set; }

        public string NombreUnidadLongitud { get; set; }

        public string NombreTalla { get; set; }

        public string NombreColor { get; set; }

        public string NombreSabor { get; set; }

        public double SubTotalVenta { get; set; }

        public double PrecioVenta { get; set; }

        public int Cantidad { get; set; }

        public double CostoDelProducto { get; set; }
       
        public double SubtotalCosto { get; set; }

        public string NombreCategoria { get; set; }

        public string NombreUnidadPresentacion { get; set; }

        public bool AbonoDesdeFacturacion { get; set; }

        public int IdPresentacionArticulo { get; set; }
    }
}
