

namespace Contratos
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBannerPrincipal
    {
        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Actualizar(Entidades.BannerPrincipal banner);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.BannerPrincipal Consultar();

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.ResultadoTransaccion Insertar(Entidades.BannerPrincipal banner);


    }
}
