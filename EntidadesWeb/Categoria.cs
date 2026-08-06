// -----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace EntidadesWeb
{
    /// <summary>
    /// Representa una categoría para una entidad con dicha propiedad.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Identificación de la categoría  en la base de datos.
        /// </summary>       
        public int IdCategoria { get; set; }

        /// <summary>
        /// Identificación de la CategoríaPadre en la base de datos.
        /// </summary>    
        public int IdCategoriaPadre { get; set; }

        private string nombre = string.Empty;

        /// <summary>
        /// Nombre de la categoría
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
                this.NombreSinEspacios = this.nombre.Replace(" ", "_").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
            }
        }


        public string NombreSinEspacios { get; set; }

        /// <summary>
        /// Descripcion de la categoría
        /// </summary> 
        public string Descripcion { get; set; }

        /// <summary>
        /// Palabras claves de la categoría
        /// </summary>   
        public string PalabraClave { get; set; }

        public string SegmentoAmigableUrlCategoria { get; set; }
    }
}
