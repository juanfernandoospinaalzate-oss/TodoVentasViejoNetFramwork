// -----------------------------------------------------------------------
// <copyright file="Enumeracion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Entidades.Enumeraciones
{
    /// <summary>
    /// Indicar un estado
    /// </summary>
    public enum Estado
    {
        /// <summary>
        /// Indica que el estado es habilitado o disponible
        /// </summary>
        Habilitado = 1,

        /// <summary>
        /// Indica que el estado es inhabilitado o no disponible
        /// </summary>
        Inhabilitado = 0
    }

    public enum EstadoInventario
    {
        /// <summary>
        /// Indica que el estado es Inactivo o no disponible
        /// </summary>
        Inactivo = 0,

        /// <summary>
        /// Indica que el estado es activo o disponible
        /// </summary>
        Activo = 1    
    }

    /// <summary>
    /// Indica si se están insertando o editando datos de la base de datos.
    /// </summary>
    public enum Operacion
    {
        /// <summary>
        /// Indica que se está ejecutando una operación de inserción de datos.
        /// </summary>
        Insercion = 0,

        /// <summary>
        /// Indica que se está ejecutando una operación de actualización de datos.
        /// </summary>
        Edición = 1,

        /// <summary>
        /// Indica que no se está ejecutando una operación ni de inserción ni de actualización de datos.
        /// </summary>
        Indeterminada = 2
    }

    public enum FuncionPayU
    {
        ListarFranquiciasDisponibles = 0
    }

    public enum BannerPrincipalVideoDataSource
    {
        vimeo = 0,
        youtube = 1
    }
    public enum BannerPrincipaTarget
    {
        Blank = 0,
        Self = 1
    }

    public enum OpcionConsultaOrdenCompra
    {
        NumeroOrdenCompra = 0,
        NumeroIdentificacion = 1,
        NombreCliente = 2
    }

    /// <summary>
    /// Dummy para cumplir con reglas stylecop
    /// </summary>
    public enum Enumeracion
    {
        /// <summary>
        /// Dummy para cumplir con reglas stylecop
        /// </summary>
        Dummy = 0,

        /// <summary>
        /// Dummy para cumplir con reglas stylecop
        /// </summary>
        Dummy2 = 1
    }
}
