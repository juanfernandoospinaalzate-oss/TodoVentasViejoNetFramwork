//-----------------------------------------------------------------------
// <copyright file="PresentacionArticuloPorAlmacen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class PresentacionArticuloPorAlmacen
    {
        public int IdPresentacionArticuloPorAlmacen { get; set; }

        public int IdAlmacen { get; set; }

        public int Existencia { get; set; }

        public int MaxExistencias { get; set; }

        public int MinExistencias { get; set; }

        public decimal CostoUnitario { get; set; }

        public decimal PrecioVenta { get; set; }

        public decimal Iva { get; set; }

        // NombreCompleto del Almacen
        public string NombreCompleto { get; set; }

        public string NombrePresentacionArticulo { get; set; }

        public string DescripcionBreve { get; set; }        
    }
}