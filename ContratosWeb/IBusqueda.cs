// -----------------------------------------------------------------------
// <copyright file="IBusqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBusqueda
    {
        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<string> Listar(string texto);

        [OperationContract]
        [CLSCompliant(true)]
        void Insertar(string texto);

        [OperationContract]
        [CLSCompliant(true)]
        System.Collections.ObjectModel.ReadOnlyCollection<double> Buscar(string texto);

        [OperationContract]
        [CLSCompliant(true)]
        string GenerarConsultaSQL(string textoBusqueda);
    }
}