//-----------------------------------------------------------------------
// <copyright file="DetalleVenta.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public string NombreMarca { get; set; }
        public string Titulo { get; set; }
        public string CodigoEan { get; set; }
        public string NombreUnidadVolumen { get; set; }
        public int VlrVolumenLargo { get; set; }
        public int VlrVolumenAncho { get; set; }
        public int VlrVolumenProfundidad { get; set; }
        public int VlrContenidoVolumetrico { get; set; }
        public string NombreUnidadMasa { get; set; }
        public int VlrUnidadMasa { get; set; }
        public string NombreUnidadLongitud { get; set; }
        public int VlrUnidadLongitud { get; set; }
        public string NombreTalla { get; set; }
        public string NombreColor { get; set; }
        public string NombreSabor { get; set; }
        public double PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public double CostoDelProducto { get; set; }
        public double SubTotalVenta { get; set; }
        public double SubtotalCosto { get; set; }
        public string NombreCategoria { get; set; }
        public string CaminoSubCategorias { get; set; }
        public int IdPresentacionArticulo { get; set; }
    }
}
