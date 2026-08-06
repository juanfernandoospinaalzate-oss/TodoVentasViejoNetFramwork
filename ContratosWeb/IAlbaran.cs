//-----------------------------------------------------------------------
// <copyright file="IAlbaran.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ContratosWeb
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IAlbaran
    {
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.Albaran albaran);
    }
}
