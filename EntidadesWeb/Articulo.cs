// -----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace EntidadesWeb
{
    using System.Collections.Generic;

    /// <summary>
    /// Representa un Artículo de la base de datos
    /// </summary>
    public class Articulo
    {
        /// <summary>
        /// Propiedades del objeto Artículo
        /// </summary>
        public Articulo()
        {
            this.Categoria = new Categoria();
            this.Marca = new Marca();
            this.PresentacionesDelArticulo = new List<EntidadesWeb.PresentacionArticulo>();
        }

        public List<EntidadesWeb.PresentacionArticulo> PresentacionesDelArticulo { get; set; }

        /// <summary>
        /// Propiedad del objeto Categoría
        /// </summary>
        public EntidadesWeb.Categoria Categoria { get; set; }

        /// <summary>
        /// Propiedad del objeto Marca
        /// </summary>
        public EntidadesWeb.Marca Marca { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public int IdArticulo { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public string PalabrasRelacionArticulo { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public int GarantiaMeses { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public string VideoYoutube { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public string MetaDescripcion { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public string MetaKeyWords { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool UnidadVolumen { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool UnidadLongitud { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool UnidadMasa { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool Talla { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool Color { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool ENLinea { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool PreOrdenar { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool Sabor { get; set; }

        /// <summary>
        /// Propiedad del objeto artículo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Indica si el filtro para unidades de la presentación se encuentra activo
        /// </summary>
        public bool UnidadPresentacion { get; set; }
    }
}
