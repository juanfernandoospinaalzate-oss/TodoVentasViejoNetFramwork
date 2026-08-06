//-----------------------------------------------------------------------
// <copyright file="ILogin.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface ILogin 
    {
        /// <summary>
        /// Ingreso de un cliente al sistema.
        /// </summary>
        /// <param name="login">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Ingresar(EntidadesWeb.Login login);

        /// <summary>
        /// Inserta una presentación de artículo en el carrito, sin hacer suma cuando el item ya existe para ese usuario
        /// </summary>
        /// <param name="carrito">Item de carrito a insertar. Tiene que contener el Id del usuario</param>
        /// <returns>Resultado transacción con la cantidad de registros afectados</returns>
        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ResultadoTransaccion InsertarItemCarrito(System.Collections.Generic.List<EntidadesWeb.ItemCarrito> carrito);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito> ListarItemCarritoPorIdUsuario(int IdUsuario);
    }
}
