

namespace ServiciosWeb.Facturacion
{
    using System.Collections.Generic;
    using Entidades;

    public class Facturacion : Contratos.IFacturacion
    {
        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string codigoEAN)
        {
            Validacion.Facturacion.Facturacion Factura = new Validacion.Facturacion.Facturacion();
            return Factura.ConsultarPresentacionPorCodigoEAN(codigoEAN);
        }

        public int GenerarFactura(List<PresentacionArticulo> listaPresntacionArticulo, Entidades.Cliente cliente, Entidades.MetodoDePago metodoDePago, Entidades.EstadoVenta estadoDeLaVenta)
        {
            Validacion.Facturacion.Facturacion Factura = new Validacion.Facturacion.Facturacion();

            // Recorrer las presentaciones
            int i = 0;
            while (i < listaPresntacionArticulo.Count)
            {
                Validacion.TablasMaestras.PresentacionArticulo ObjPresentacionArticulo = new Validacion.TablasMaestras.PresentacionArticulo();
                // La recuperación de datos sobreescribe el campo "Existencias" usado como cantidad vendida para cada  referencia
                // se saca copia para ser resstablecida luego de la consula en base de datos
                int CantidadCompradaPorArticulo = listaPresntacionArticulo[i].Existencias;
                listaPresntacionArticulo[i] = ObjPresentacionArticulo.ConsultarPorId(listaPresntacionArticulo[i].IdPresentacionArticulo);
                if (listaPresntacionArticulo[i] != null)
                {
                    listaPresntacionArticulo[i].Existencias = CantidadCompradaPorArticulo;
                }
                
                i++;
            }

            return Factura.GenerarFactura(listaPresntacionArticulo, cliente, metodoDePago, estadoDeLaVenta);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            Validacion.Facturacion.Facturacion Factura = new Validacion.Facturacion.Facturacion();
            return Factura.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}
