namespace ContratosWeb
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IPaisDepartamentoCiudad
    {
        /// <summary>
        /// Obtiene una lista con todos los países disponibles
        /// </summary>
        /// <returns>Lista con todos los países disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais> ListarPais();

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> ListarDepartamento(int idPais);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> ListarCiudad(int IdDpto);


    }
}
