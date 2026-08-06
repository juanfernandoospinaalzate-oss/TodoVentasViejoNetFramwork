

namespace ContratosWeb
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBusquedasSecuencialesWeb
    {
        [OperationContract]
        [CLSCompliant(true)]
        List<EntidadesWeb.Categoria> BusquedaSecuencialCategoriaPorIdCategoriaPadre(List<EntidadesWeb.Categoria> listaCategoriasCompleta, int IdCategoria);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Color BusquedaSecuencialColorPorNombre(List<EntidadesWeb.Color> listaColores, string nombreColor);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.ItemCarrito BusquedaSecuencialItemCarritoPorId(List<EntidadesWeb.ItemCarrito> listaItemCarrito, int idIPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.PresentacionArticulo BusquedaSecuencialPresentacionArticulo(List<EntidadesWeb.PresentacionArticulo> presentacionesArticulo, List<string> filtros, List<string> valoresFiltros);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Sabor BusquedaSecuencialSaborPorNombre(List<EntidadesWeb.Sabor> listaSabores, string nombreSabor);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.Talla BusquedaSecuencialTallaPorNombre(List<EntidadesWeb.Talla> listaTallas, string nombreTalla);

        [OperationContract]
        [CLSCompliant(true)]
        EntidadesWeb.UnidadPresentacion BusquedaSecuencialUnidadPresentacionPorNombre(List<EntidadesWeb.UnidadPresentacion> listaUnidadPresentacion, string nombreUnidadPresentacion);
    }
}