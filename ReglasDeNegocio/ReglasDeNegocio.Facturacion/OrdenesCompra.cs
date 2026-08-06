// -----------------------------------------------------------------------
// <copyright file="OrdenesCompra.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.Facturacion
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    public class OrdenesCompra : Contratos.IOrdenesCompra
    {
        public Entidades.ResultadoTransaccion ConfirmarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente, int IdAlbaran)
        {
            AccesoDatos.Facturacion.OrdenesCompra objOrdenesCompra = new AccesoDatos.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ConfirmarOrdenCompra(listaPresentacionArticulo, cliente, IdAlbaran);
        }

        public Entidades.ResultadoTransaccion EliminarOrdenCompraLogico(int IdAlbaran)
        {
            AccesoDatos.Facturacion.OrdenesCompra objOrdenesCompra = new AccesoDatos.Facturacion.OrdenesCompra();
            return objOrdenesCompra.EliminarOrdenCompraLogico(IdAlbaran);
        }

        public int GenerarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente)
        {
            AccesoDatos.Facturacion.OrdenesCompra objOrdenesCompra = new AccesoDatos.Facturacion.OrdenesCompra();
            return objOrdenesCompra.GenerarOrdenCompra(listaPresentacionArticulo, cliente);
        }

        public ReadOnlyCollection<Entidades.OrdenesCompra> ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra opcionBusqueda, string filtroBusqueda)
        {
            AccesoDatos.Facturacion.OrdenesCompra objOrdenesCompra = new AccesoDatos.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(opcionBusqueda, filtroBusqueda);
        }

        public ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListarOrdenesCompraDetallePorIdentificador(int IdAlbaran)
        {
            AccesoDatos.Facturacion.OrdenesCompra objOrdenesCompra = new AccesoDatos.Facturacion.OrdenesCompra();
            return objOrdenesCompra.ListarOrdenesCompraDetallePorIdentificador(IdAlbaran);
        }
    }
}
