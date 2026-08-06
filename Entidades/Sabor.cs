// -----------------------------------------------------------------------
// <copyright file="Sabor.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Entidades
{
    /// <summary>
    /// Representa un Sabor de la base de datos
    /// </summary>
    public class Sabor
    {
        /// <summary>
        /// Identificación del Sabor en la base de datos.
        /// </summary>  
        public int IdSabor { get; set; }
        
        /// <summary>
        /// Nombre del Sabor
        /// </summary>
        public string Nombre { get; set; }
    }
}
