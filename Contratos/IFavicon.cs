

namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IFavicon
    {
        [OperationContract]
        bool CargarIcono(byte[] icono);

        [OperationContract]
        byte[] DescargarIcono();

        [OperationContract]
        bool EliminarIcono();
    }
}
