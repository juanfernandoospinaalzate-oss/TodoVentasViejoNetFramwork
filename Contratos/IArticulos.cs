// -----------------------------------------------------------------------
// <copyright file="IArticulos.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Contratos
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Articulos.svc
    /// </summary>
    [ServiceContract]
    public interface IArticulos
    {
        /// <summary>
        /// Inserta un artículo nuevo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Insertar(Entidades.Articulo articulo);

        /// <summary>
        /// Actualiza los datos de un artículo existente en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean actualizar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Articulo articulo);

        /// <summary>
        /// Elimina el registro de un artículo existente en la base de datos.
        /// </summary>
        /// <param name="idarticulo">Identificación del color en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Eliminar(int idarticulo);

        /// <summary>
        /// Obtiene una lista con todos los articulos disponibles
        /// </summary>
        /// <returns>Lista con todos los articulos disponibles</returns>
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> Listar();

        /// <summary>
        /// Obtiene una lista con todos los articulos disponibles
        /// </summary>
        /// <returns>Lista con todos los articulos disponibles</returns>
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> ListarPorEstado(Entidades.Enumeraciones.EstadoInventario estado);
    }
}
