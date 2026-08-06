

namespace Fachada.Facturacion
{
    using System.Collections.Generic;
    using Entidades;

    public class Facturacion : Contratos.IFacturacion
    {
        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN)
        {
            ServicioFacturacion.FacturacionClient Factura = new ServicioFacturacion.FacturacionClient();
            return Factura.ConsultarPresentacionPorCodigoEAN(CodigoEAN);
        }

        public int GenerarFactura(List<PresentacionArticulo> listaPresntacionArticulo, Entidades.Cliente cliente, Entidades.MetodoDePago metodoDePago, Entidades.EstadoVenta estadoDeLaVenta)
        {
            ServicioFacturacion.FacturacionClient objFactura = new ServicioFacturacion.FacturacionClient();
            return objFactura.GenerarFactura(listaPresntacionArticulo.ToArray(), cliente, metodoDePago, estadoDeLaVenta);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            ServicioFacturacion.FacturacionClient objFactura = new ServicioFacturacion.FacturacionClient();
            return objFactura.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}