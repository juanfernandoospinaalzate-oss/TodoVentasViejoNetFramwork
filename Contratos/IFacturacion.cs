namespace Contratos
{
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IFacturacion
    {
        [OperationContract]
        Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string codigoEan);

        [OperationContract]
        int GenerarFactura(List<Entidades.PresentacionArticulo> listaPresntacionArticulo, Entidades.Cliente cliente, Entidades.MetodoDePago metodoDePago,  Entidades.EstadoVenta estadoDeLaVenta);

        [OperationContract]
        int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo);
    }
}
