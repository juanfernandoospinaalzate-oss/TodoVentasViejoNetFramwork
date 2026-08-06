

namespace ContratosWeb
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBannerPrincipal
    {
        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.BannerPrincipal Consultar();
    }
}
