

namespace Validacion.Facturacion
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    public class OrdenesCompra : Contratos.IOrdenesCompra
    {
        public Entidades.ResultadoTransaccion ConfirmarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente, int IdAlbaran)
        {
            ReglasDENegocio.Facturacion.OrdenesCompra objOrdenesCompra = new ReglasDENegocio.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ConfirmarOrdenCompra(listaPresentacionArticulo, cliente, IdAlbaran);
        }

        public Entidades.ResultadoTransaccion EliminarOrdenCompraLogico(int IdAlbaran)
        {
            ReglasDENegocio.Facturacion.OrdenesCompra objOrdenesCompra = new ReglasDENegocio.Facturacion.OrdenesCompra();
            return objOrdenesCompra.EliminarOrdenCompraLogico(IdAlbaran);
        }

        public int GenerarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente)
        {
            ReglasDENegocio.Facturacion.OrdenesCompra objOrdenesCompra = new ReglasDENegocio.Facturacion.OrdenesCompra();
            return objOrdenesCompra.GenerarOrdenCompra(listaPresentacionArticulo, cliente);
        }

        public ReadOnlyCollection<Entidades.OrdenesCompra> ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra opcionBusqueda, string filtroBusqueda)
        {
            ReglasDENegocio.Facturacion.OrdenesCompra objOrdenesCompra = new ReglasDENegocio.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(opcionBusqueda, filtroBusqueda);
        }

        public ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListarOrdenesCompraDetallePorIdentificador(int IdAlbaran)
        {
            ReglasDENegocio.Facturacion.OrdenesCompra objOrdenesCompra = new ReglasDENegocio.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ListarOrdenesCompraDetallePorIdentificador(IdAlbaran);
        }
    }
}
