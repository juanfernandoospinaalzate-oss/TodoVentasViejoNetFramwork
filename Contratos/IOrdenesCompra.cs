//-----------------------------------------------------------------------
// <copyright file="IOrdenesCompra.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Entidades.Enumeraciones;

    [ServiceContract]
    public interface IOrdenesCompra
    {
        [OperationContract]
        [CLSCompliant(true)]
        int GenerarOrdenCompra(List<Entidades.PresentacionArticulo> listaPresentacionArticulo, Entidades.Cliente cliente);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompra> ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra opcionBusqueda, string filtroBusqueda);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListarOrdenesCompraDetallePorIdentificador(int IdAlbaran);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion EliminarOrdenCompraLogico(int IdAlbaran);


        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion ConfirmarOrdenCompra(List<Entidades.PresentacionArticulo> listaPresentacionArticulo, Entidades.Cliente cliente, int IdAlbaran);

    }
}