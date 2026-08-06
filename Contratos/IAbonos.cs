//-----------------------------------------------------------------------
// <copyright file="IAbonos.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IAbonos
    {
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Abonos> Listar(string criterioBusqueda);
    }
}
