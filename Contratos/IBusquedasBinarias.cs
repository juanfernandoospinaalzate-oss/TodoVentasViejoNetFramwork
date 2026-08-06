

namespace Contratos
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBusquedasBinarias
    {
        [OperationContract]
        [CLSCompliant(true)]
        int BusquedaBinariaArticuloIndiceDondeInsertar(ref List<Entidades.Articulo> ListaArticulos, int idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Articulo BusquedaBinariaArticuloPorIdArticulo(ref List<Entidades.Articulo> ListaArticulos, int idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Articulo BusquedaBinariaArticuloPorIdArticulo(List<Entidades.Articulo> ListaArticulos, long idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Articulo BusquedaBinariaArticuloPorIdArticulo(List<Entidades.Articulo> ListaArticulos, double idArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        void BusquedaBinariaBorradoPresentacionArticuloPorIdPresentacionArticulo(List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, double idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Categoria BusquedaBinariaCategoriaPorIdCategoria(List<Entidades.Categoria> listaCategorias, int idCategoria);

        [OperationContract]
        [CLSCompliant(true)]
        int BusquedaBinariaPresentacionArticuloIndiceDondeInsertar(ref List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(ref List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, int idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.PresentacionArticulo BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(List<Entidades.PresentacionArticulo> ListaPresentacionArticulos, double idPresentacionArticulo);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Marca BusquedaBinariaMarcaPorIdMarca(List<Entidades.Marca> listaMarcas, int idMarca);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.UnidadVolumen BusquedaBinariaUnidadDeVolumenPorIdUnidadDeVolumen(List<Entidades.UnidadVolumen> listaUnidadVolumen, int idUnidadVolumen);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.UnidadMasa BusquedaBinariaUnidadDeMasaPorIdUnidadDeMasa(List<Entidades.UnidadMasa> listaUnidadesMasa, int idUnidadMasa);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.UnidadLongitud BusquedaBinariaUnidadLongitudPorIdUnidadLongitud(List<Entidades.UnidadLongitud> listaUnidadesLongitud, int idUnidadLongitud);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Talla BusquedaBinariaTallaPorIdTalla(List<Entidades.Talla> listaTallas, int idTalla);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.Sabor BusquedaBinariaSaborPorIdSabor(List<Entidades.Sabor> listaSabores, int idSabor);

        [OperationContract]
        [CLSCompliant(true)]
        Entidades.UnidadPresentacion BusquedaBinariaUnidadPresentacionPorIdUnidadPresentacion(List<Entidades.UnidadPresentacion> listaUnidadPresentacion, int idUnidadPresentacion);
    }
}