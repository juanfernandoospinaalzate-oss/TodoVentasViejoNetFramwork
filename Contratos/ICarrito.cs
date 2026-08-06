//-----------------------------------------------------------------------
// <copyright file="ICarrito.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface ICarrito
    {
        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion EliminarPorIdPresentacionArticulo(int IdpresentacionArticulo);
    }
}
