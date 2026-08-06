

namespace Contratos
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBusquedasSecuenciales
    {
        [OperationContract]
        [CLSCompliant(true)]
        List<Entidades.Categoria> BusquedaSecuencialCategoriaPorIdCategoriaPadre(List<Entidades.Categoria> listaCategoriasCompleta, int IdCategoria);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Color BusquedaSecuencialColorPorNombre(List<Entidades.Color> listaColores, string nombreColor);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.PresentacionArticulo BusquedaSecuencialPresentacionArticulo(List<Entidades.PresentacionArticulo> presentacionesArticulo, List<string> filtros, List<string> valoresFiltros);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Sabor BusquedaSecuencialSaborPorNombre(List<Entidades.Sabor> listaSabores, string nombreSabor);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Talla BusquedaSecuencialTallaPorNombre(List<Entidades.Talla> listaTallas, string nombreTalla);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.UnidadPresentacion BusquedaSecuencialUnidadPresentacionPorNombre(List<Entidades.UnidadPresentacion> listaUnidadPresentacion, string nombreUnidadPresentacion);
    }
}