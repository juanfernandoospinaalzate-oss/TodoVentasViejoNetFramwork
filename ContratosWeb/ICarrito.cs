namespace ContratosWeb
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    /// <summary>
    /// Administra los datos del carrito de compras
    /// </summary>
    [ServiceContract]
    public interface ICarrito
    {
        /// <summary>
        /// Actualiza la cantidad de un registro en el carrito
        /// </summary>
        /// <param name="carrito">Datos del carrito, solo se necesita la nueva cantidad y el identificador del registro</param>
        /// <returns>Resultado con mensaje y cantida de registros afectados</returns>
        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.ItemCarrito carrito);

        /// <summary>
        /// Recupera todos los items de carrito asociados a la identificación del usuario
        /// </summary>
        /// <param name="IdUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Lisca con los registros recuperados</returns>
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito> Listar(int idUsuario);

        /// <summary>
        /// Elimina un item del carrito
        /// </summary>
        /// <param name="idItemCarrito">Identificación única del registro</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTransaccion Eliminar(int idItemCarrito);

        /// <summary>
        /// Ingresa un registro nuevo al carrito
        /// </summary>
        /// <param name="carrito">Datos a registrar, idenficiación del usuario, identificación de la presentación del artículo y cantidad</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.ItemCarrito carrito);

        /// <summary>
        /// Recupera el registro del carrito asociado a los parámetros para recuperar la cantidad guardad en el carrito
        /// </summary>
        /// <param name="IdPresentacionArticulo">Identificación de la presentación de artículo</param>
        /// <param name="IdUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Item de carrito con su Id, la cantidad y nombre</returns>
        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ItemCarrito ConsultarPorIdPresentacionArticulo(int IdPresentacionArticulo, int IdUsuario);

        [OperationContract]
        [CLSCompliant(true)]
        double TotalPorIdUsuario(int IdUsuario);

        [OperationContract]
        [CLSCompliant(true)]
        string GenerarPreferenciaPago(List<EntidadesWeb.ItemCarrito> ListadoCarrito, EntidadesWeb.Cliente objCliente, EntidadesWeb.Direccion objDireccion, EntidadesWeb.Enumeraciones.MedioPago formaDePago, double tasaDeCambioDolar, string urlBase);
    }
}
