namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ICiudad
    {
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Ciudad ciudad);

        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Ciudad> Listar(int idDpto);

        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idCiudad);

        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Ciudad ciudad);

    }
}
