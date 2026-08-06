//-----------------------------------------------------------------------
// <copyright file="DetalleAlbaran.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    public class DetalleAlbaran
    {
        public int IdDetalleAlbaran { get; set; }
        public int IdAlbaran { get; set; }
        public int IdCliente { get; set; }

        public string NombreMarca { get; set; }
        public string Titulo { get; set; }
        public string NombreUnidadVolumen { get; set; }

        public float VlrVolumenLargo { get; set; }
        public float VlrVolumenAncho { get; set; }
        public float VlrVolumenProfundidad { get; set; }

        public float VlrContenidoVolumetrico { get; set; }

        public string NombreUnidadMasa { get; set; }

        public float VlrUnidadMasa { get; set; }

        public string NombreUnidadLongitud { get; set; }

        public float VlrUnidadLongitud { get; set; }


        public string NombreTalla { get; set; }

        public string NombreColor { get; set; }

        public string NombreSabor { get; set; }


        public float PrecioVenta { get; set; }

        public int Cantidad { get; set; }

        public float CostoDelProducto { get; set; }

        public float SubTotalVenta { get; set; }

        public float SubtotalCosto { get; set; }


        public string NombreCategoria { get; set; }

        public string CaminoSubCategorias { get; set; }

        public int IdPresentacionArticulo { get; set; }

        public string NombreUnidadPresentacion { get; set; }

        public float VlrUnidadPresentacion { get; set; }

    }
}
