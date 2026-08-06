// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -------------------------------------------------------------------
namespace Entidades
{
    using System;

    /// <summary>
    /// Representa un Presentación Artículo de la base de datos
    /// </summary>
    public class PresentacionArticulo
    {
        /// <summary>
        /// constructor del formulario
        /// </summary>
        public PresentacionArticulo()
        {
            this.Talla = new Talla();
            this.Color = new Color();
            this.UnidadMasa = new UnidadMasa();
            this.UnidadVolumen = new UnidadVolumen();
            this.UnidadLongitud = new UnidadLongitud();
            this.Sabor = new Sabor();
            this.UnidadPresentacion = new UnidadPresentacion();
            this.Articulo = new Entidades.Articulo();
        }

        /// <summary>
        /// Identificador único de la presentación de artículo
        /// </summary>
        public int IdPresentacionArticulo { get; set; }
        
        /// <summary>
        /// Identificador único del artículo padre
        /// </summary>
        public Entidades.Articulo Articulo { get; set; }

        /// <summary>
        /// Código único correspondiente al código de barras
        /// </summary>
        public string CodigoEAN { get; set; }

        /// <summary>
        /// Nombre de la presentación del artículo (Puede coincidir con el nombre del artículo padre)
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece descripción corta
        /// </summary>
        public string DescripcionBreve { get; set; }

        /// <summary>
        /// Obtiene o establece el color de la presentación del artículo
        /// </summary>
        public Entidades.Color Color { get; set; }

        /// <summary>
        /// Obtiene o establece la talla de la presentación del artículo
        /// </summary>
        public Entidades.Talla Talla { get; set; }

        /// <summary>
        /// Obtiene o establece la imagen número 1 correspondiente a la presentación del artículo
        /// </summary>
        public byte[] Imagen1 { get; set; }

        /// <summary>
        /// Obtiene o establece la imagen número 2 correspondiente a la presentación del artículo
        /// </summary>
        public byte[] Imagen2 { get; set; }

        /// <summary>
        /// Obtiene o establece la imagen número 1 correspondiente a la presentación del artículo
        /// </summary>
        public byte[] Imagen3 { get; set; }

        /// <summary>
        /// Obtiene o establece la imagen número 1 correspondiente a la presentación del artículo
        /// </summary>
        public byte[] Imagen4 { get; set; }

        /// <summary>
        /// Obtiene o establece la imagen número 1 correspondiente a la presentación del artículo
        /// </summary>
        public byte[] Imagen5 { get; set; }

        /// <summary>
        /// Obtiene o establece la imagen número 1 correspondiente a la presentación del artículo
        /// </summary>
        public byte[] Imagen6 { get; set; }
        
        /// <summary>
        /// Obtiene o establece la fecha de registro en la base de datos
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece la unidad de masa de la presentación del artículo
        /// </summary>
        public Entidades.UnidadMasa UnidadMasa { get; set; }

        public double VlrUnidadMasa { get; set; }

        
        public Entidades.UnidadVolumen UnidadVolumen { get; set; }

        public double VlrUnidadVolumenLargo { get; set; }

        public double VlrUnidadVolumenAncho { get; set; }

        public double VlrUnidadVolumenProfundidad { get; set; }

        public double VlrContenidoVolumetrico { get; set; }

        public Entidades.UnidadLongitud UnidadLongitud { get; set; }

        public double VlrUnidadLongitud { get; set; }

        public bool EnLinea { get; set; }

        public bool Activo { get; set; }

        public double Precio { get; set; }

        public int Existencias { get; set; }

        public Entidades.Sabor Sabor { get; set; }

        public double CostoArticulo { get; set; }

        public bool PreOrden { get; set; }

        public Entidades.UnidadPresentacion UnidadPresentacion { get; set; }

        public double VlrUnidadPresentacion { get; set; }

        public DateTime FechaProximoVencimiento { get; set; }

        public bool UsarFechaProximoVencimiento { get; set; }

        public bool UsarDescuento { get; set; }

        public bool UsarPorcentajeDescuento { get; set; }

        public double ValorPorcentajeDescuento { get; set; }

        public bool UsarValorFijoDescuento { get; set; }

        public double ValorFijoDescuento { get; set; }

        public DateTime FechaInicioDescuento { get; set; }

        public DateTime FechaFinalDescuento { get; set; }
    }
}
