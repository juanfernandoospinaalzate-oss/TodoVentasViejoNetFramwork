//-----------------------------------------------------------------------
// <copyright file="IVenta.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ContratosWeb
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IVenta
    {

        [OperationContract]
        EntidadesWeb.Venta ConsultarParaVenta(int IdUsuario,  System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion);

        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Venta venta, System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta> ConsultarParaDetalleVenta(int IdUsuario, System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion);

        [OperationContract]
        EntidadesWeb.ResultadoTransaccion InsertarDetalleVenta(EntidadesWeb.DetalleVenta detalleVenta, System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion);

        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Eliminar(int IdUsuario);

        [OperationContract]
        EntidadesWeb.Venta ConsultarParaVentaModoInvitado(System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta> ConsultarParaDetalleVentaModoInvitado(System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion);
        
    }
}
