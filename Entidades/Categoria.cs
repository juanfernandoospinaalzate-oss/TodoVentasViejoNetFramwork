// -----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Entidades
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
       
          /// <summary>
         /// Nombre de la categoría
        /// </summary>
      public string Nombre { get; set; }
        
           /// <summary>
          /// Descripcion de la categoría
         /// </summary> 
      public string Descripcion { get; set; }
        
      /// <summary>
      /// Palabras claves de la categoría
        /// </summary>   
      public string PalabrasClave { get; set; }
    }
}
