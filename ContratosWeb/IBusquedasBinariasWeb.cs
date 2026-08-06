

namespace ContratosWeb
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBusquedasBinariasWeb
    {
        [OperationContract]
        [CLSCompliant(true)]
        int BusquedaBinariaArticuloIndiceDondeInsertar(ref List<EntidadesWeb.Articulo> ListaArticulos, int idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Articulo BusquedaBinariaArticuloPorIdArticulo(ref List<EntidadesWeb.Articulo> ListaArticulos, int idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Articulo BusquedaBinariaArticuloPorIdArticulo(List<EntidadesWeb.Articulo> ListaArticulos, long idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Articulo BusquedaBinariaArticuloPorIdArticulo(List<EntidadesWeb.Articulo> ListaArticulos, double idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Categoria BusquedaBinariaCategoriaPorIdCategoria(List<EntidadesWeb.Categoria> listaCategorias, int idCategoria);

        [OperationContract]
        [CLSCompliant(true)]
        int BusquedaBinariaPresentacionArticuloIndiceDondeInsertar(ref List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(ref List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulos, double idPresentacionArticulo);
    }
}