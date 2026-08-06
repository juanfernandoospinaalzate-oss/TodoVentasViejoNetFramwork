// -----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Entidades
{
    using System.Collections.Generic;

    /// <summary>
    /// Representa un Artículo de la base de datos
    /// </summary>
    public class Articulo
    {
        private List<Entidades.PresentacionArticulo> PresentacionesArticulo = new List<Entidades.PresentacionArticulo>();

        /// <summary>
        /// creación del objeto categoría de tipo Entidad.Categoría
        /// </summary>
        private Entidades.Categoria categoria = new Entidades.Categoria();

        /// <summary>
        /// creación del objeto marca de tipo Entidad.Marca
        /// </summary>
        private Entidades.Marca marca = new Entidades.Marca();

        /// <summary>
        /// Propiedades del objeto Artículo
        /// </summary>
        public Articulo()
        {
            this.Categoria = new Categoria();
            this.Marca = new Marca();
        }

        /// <summary>
        /// Propiedad del objeto Categoría
        /// </summary>
        public Entidades.Categoria Categoria
        {
            get
            {
                return this.categoria;
            }

            set
            {
                this.categoria = value;
            }
        }

        /// <summary>
        /// Propiedad del objeto Marca
        /// </summary>
        public Entidades.Marca Marca 
        {
            get
            {
                return this.marca;
            }

            set
            {
                this.marca = value;
            }
        }

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
        // public string DescripcionCorta { get; set; }

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

        public List<Entidades.PresentacionArticulo> PresentacionesDelArticulo
        {
            get
            {
                return this.PresentacionesArticulo;
            }

            set
            {
                this.PresentacionesArticulo = value;
            }
        }
    }
}