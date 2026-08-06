// -----------------------------------------------------------------------
// <copyright file="IBusqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Contratos
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBusqueda
    {
        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Eliminar();

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Aprobar();

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Busqueda> Listar(bool Eliminado, bool Aprobado);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> Buscar(string texto, System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulos);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> BuscarPorEstado(string texto, System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulos, Entidades.Enumeraciones.Estado estado);
    }
}
