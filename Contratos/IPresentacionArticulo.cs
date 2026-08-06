// -----------------------------------------------------------------------
// <copyright file="IPresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ---------------------------------------------------------------------

namespace Contratos
{
    using System;
    using System.ServiceModel;
    //// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITallas" in both code and config file together.

    /// <summary>
    /// interface con los contratos de operación para el servicio web Tallas.svc
    /// </summary>
    [ServiceContract]
    public interface IPresentacionArticulo
    {
        /// <summary>
        /// Inserta registros del formulario Presentación Artículo en la base de datos.
        /// </summary>
        /// <param name="presentacion">Objeto con los datos que se desean insertar</param>
        /// <param name="kardex">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticulo presentacion, Entidades.Kardex kardex);

        /// <summary>
        /// Actualiza registros del formulario Presentación Artículo en la base de datos.
        /// </summary>
        /// <param name="presentacion">Objeto con los datos que se desean modificar</param>
        /// <param name="kardex">Objeto con los datos que se desean modificar</param>
        /// <returns></returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticulo presentacion, Entidades.Kardex kardex);

        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticulo);

        [OperationContract]
        bool SubirImagen(byte[] imagen, string nombreImagen, char letraImagen, DateTime fechaOut);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idArticulo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        [OperationContract]
        Entidades.ResultadoTransaccion ActivarInactivarPorArticulo(int idArticulo, Entidades.Enumeraciones.Estado estado);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> Listar(int idArticulo);

        [OperationContract]
        bool VerificarVentaArticulo(int idPresentacionArticulo);

        [OperationContract]
        bool VerificarRelacionCarrito(int idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> ListarTodo();

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> ListarPendientesActualizacion();

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> ListarActivos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idArticulo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        [OperationContract]
        Entidades.ResultadoTransaccion ActivarInactivarEnLineaPorArticulo(int idArticulo, Entidades.Enumeraciones.Estado estado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idArticulo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        [OperationContract]
        Entidades.ResultadoTransaccion ActivarInactivarPreordenPorArticulo(int idArticulo, Entidades.Enumeraciones.Estado estado);

        [OperationContract]
        Entidades.PresentacionArticulo ConsultarPorId(int idPresentacionArticulo);

        [OperationContract]
        Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN);

        [OperationContract]
        int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo);
    }
}
