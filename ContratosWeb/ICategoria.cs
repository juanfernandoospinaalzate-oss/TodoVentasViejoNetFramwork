namespace ContratosWeb
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ICategoria
    {
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> Listar();

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> ListarCategoriasUsadas();
    }
}
