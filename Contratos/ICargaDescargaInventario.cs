//-----------------------------------------------------------------------
// <copyright file="ICargaDescargaInventario.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ICargaDescargaInventario
    {
        [OperationContract]
        Entidades.ResultadoTransaccion Cargar(string codigoBarras, int cantidad, Entidades.Kardex kardex, bool ActivarPresentacionArticulo);

        [OperationContract]
        Entidades.ResultadoTransaccion Descargar(string codigoBarras, int cantidad, Entidades.Kardex kardex);
    }
}
