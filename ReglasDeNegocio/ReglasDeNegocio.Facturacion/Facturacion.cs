// -----------------------------------------------------------------------
// <copyright file="Facturacion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.Facturacion
{
    using System.Collections.Generic;
    using Entidades;

    public class Facturacion : Contratos.IFacturacion
    {
        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN)
        {
            AccesoDatos.Facturacion.Facturacion Factura = new AccesoDatos.Facturacion.Facturacion();
            return Factura.ConsultarPresentacionPorCodigoEAN(CodigoEAN);
        }

        public int GenerarFactura(List<PresentacionArticulo> listaPresntacionArticulo, Entidades.Cliente cliente, Entidades.MetodoDePago metodoDePago, Entidades.EstadoVenta estadoDeLaVenta)
        {
            AccesoDatos.Facturacion.Facturacion Factura = new AccesoDatos.Facturacion.Facturacion();
            return Factura.GenerarFactura(listaPresntacionArticulo, cliente, metodoDePago, estadoDeLaVenta);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            AccesoDatos.Facturacion.Facturacion Factura = new AccesoDatos.Facturacion.Facturacion();
            return Factura.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}
