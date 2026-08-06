// -----------------------------------------------------------------------
// <copyright file="CargaDescargaInventario.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.Inventario
{
    public class CargaDescargaInventario : Contratos.ICargaDescargaInventario
    {
        public Entidades.ResultadoTransaccion Cargar(string codigoBarras, int cantidad, Entidades.Kardex kardex, bool ActivarPresentacionArticulo)
        {
            AccesoDatos.Inventario.CargaDescargaInventario CargaDescargaInventario = null;
            
            Entidades.ResultadoTransaccion ResultadoTransacción = new Entidades.ResultadoTransaccion();
            Entidades.PresentacionArticulo PresentacionArticulo = null;
            AccesoDatos.Facturacion.Facturacion Facturación = new AccesoDatos.Facturacion.Facturacion();

            // Consultar utilizando el código de barras
            PresentacionArticulo = Facturación.ConsultarPresentacionPorCodigoEAN(codigoBarras);

            // Código de barras no encontado en base de datos
            if (PresentacionArticulo.IdPresentacionArticulo == 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0073");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // La variable cantidad debe llegar negativa a la capa de datos
            if (cantidad > 0)
            {
                cantidad = cantidad * (-1);
            }

            // en este puento ya se sabe que el artículo fue encontrado en la base de datos.
            CargaDescargaInventario = new AccesoDatos.Inventario.CargaDescargaInventario(PresentacionArticulo.IdPresentacionArticulo);
            ResultadoTransacción = CargaDescargaInventario.Cargar(codigoBarras, cantidad, kardex, ActivarPresentacionArticulo);

            if (ResultadoTransacción.RegistrosAfectados == 1)
            {
                // Carga exitosa, retornamos el identificador de la presentación del artículo y el mensaje correspondiente para mostrar en pantalla
                ResultadoTransacción.ValorAuxiliar = PresentacionArticulo.IdPresentacionArticulo;
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0077");
            }

            return ResultadoTransacción;
        }

        public Entidades.ResultadoTransaccion Descargar(string codigoBarras, int cantidad, Entidades.Kardex kardex)
        {
            AccesoDatos.Inventario.CargaDescargaInventario CargaDescargaInventario = null;
            Entidades.ResultadoTransaccion ResultadoTransacción = new Entidades.ResultadoTransaccion();
            Entidades.PresentacionArticulo PresentacionArticulo = null;
            AccesoDatos.Facturacion.Facturacion Facturación = new AccesoDatos.Facturacion.Facturacion();

            // Consultar utilizando el código de barras
            PresentacionArticulo = Facturación.ConsultarPresentacionPorCodigoEAN(codigoBarras);

            // --Codigo de barras no encontado en base de datos
            if (PresentacionArticulo.IdPresentacionArticulo == 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0072");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // -- Cantidad, Cero en base de datos
            if (PresentacionArticulo.Existencias == 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0074");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // ---Ya hay existencias negativas en base de datos
            if (PresentacionArticulo.Existencias < 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0075");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // -- Existencias negativas en base de datos después del cálculo
            if ((PresentacionArticulo.Existencias - cantidad) < 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0076");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // en este puento ya se sabe que el artículo fue encontrado en la base de datos.
            CargaDescargaInventario = new AccesoDatos.Inventario.CargaDescargaInventario(PresentacionArticulo.IdPresentacionArticulo);
            ResultadoTransacción = CargaDescargaInventario.Descargar(codigoBarras, cantidad, kardex);

            if (ResultadoTransacción.RegistrosAfectados == 1)
            {
                // Descarga exitosa, retornamos el identificador de la presentación del artículo y el mensaje correspondiente para mostrar en pantalla
                ResultadoTransacción.ValorAuxiliar = PresentacionArticulo.IdPresentacionArticulo;
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0078");
            }

            return ResultadoTransacción;
        }
    }
}
