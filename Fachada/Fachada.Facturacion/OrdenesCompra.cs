

namespace Fachada.Facturacion
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    public class OrdenesCompra : Contratos.IOrdenesCompra
    {
        public Entidades.ResultadoTransaccion ConfirmarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente, int IdAlbaran)
        {
            ServicioOrdenesCompra.OrdenesCompraClient objOrdenesCompra = new ServicioOrdenesCompra.OrdenesCompraClient();
            return objOrdenesCompra.ConfirmarOrdenCompra(listaPresentacionArticulo.ToArray(), cliente, IdAlbaran);
        }

        public Entidades.ResultadoTransaccion EliminarOrdenCompraLogico(int IdAlbaran)
        {
            ServicioOrdenesCompra.OrdenesCompraClient objOrdenesCompra = new ServicioOrdenesCompra.OrdenesCompraClient();
            return objOrdenesCompra.EliminarOrdenCompraLogico(IdAlbaran);
        }

        public int GenerarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente)
        {
            ServicioOrdenesCompra.OrdenesCompraClient objOrdenesCompra = new ServicioOrdenesCompra.OrdenesCompraClient();
            return objOrdenesCompra.GenerarOrdenCompra(listaPresentacionArticulo.ToArray(), cliente);
        }

        public ReadOnlyCollection<Entidades.OrdenesCompra> ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra opcionBusqueda, string filtroBusqueda)
        {
            ServicioOrdenesCompra.OrdenesCompraClient objOrdenesCompra = new ServicioOrdenesCompra.OrdenesCompraClient();
            return objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(opcionBusqueda, filtroBusqueda);
        }

        public ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListarOrdenesCompraDetallePorIdentificador(int IdAlbaran)
        {
            ServicioOrdenesCompra.OrdenesCompraClient objOrdenesCompra = new ServicioOrdenesCompra.OrdenesCompraClient();
            return objOrdenesCompra.ListarOrdenesCompraDetallePorIdentificador(IdAlbaran);
        }
    }
}
