

namespace Validacion.Facturacion
{
    using System.Collections.Generic;
    using Entidades;

    public class Facturacion : Contratos.IFacturacion
    {
        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string codigoEAN)
        {
            ReglasDENegocio.Facturacion.Facturacion Factura = new ReglasDENegocio.Facturacion.Facturacion();
            return Factura.ConsultarPresentacionPorCodigoEAN(codigoEAN);
        }

        public int GenerarFactura(List<PresentacionArticulo> listaPresntacionArticulo, Entidades.Cliente cliente, Entidades.MetodoDePago metodoDePago, Entidades.EstadoVenta estadoDeLaVenta)
        {
            ReglasDENegocio.Facturacion.Facturacion Factura = new ReglasDENegocio.Facturacion.Facturacion();
            return Factura.GenerarFactura(listaPresntacionArticulo, cliente, metodoDePago, estadoDeLaVenta);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            ReglasDENegocio.Facturacion.Facturacion Factura = new ReglasDENegocio.Facturacion.Facturacion();
            return Factura.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}
