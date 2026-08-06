

namespace Validacion.Inventario
{
    using Entidades;

    public class CargaDescartaInventario : Contratos.ICargaDescargaInventario
    {
        public ResultadoTransaccion Cargar(string codigoBarras, int cantidad, Entidades.Kardex kardex, bool ActivarPresentacionArticulo)
        {
            ReglasDENegocio.Inventario.CargaDescargaInventario CargaDescargaInventario = null;
            CargaDescargaInventario = new ReglasDENegocio.Inventario.CargaDescargaInventario();
            Entidades.ResultadoTransaccion ResultadoTransacción = new Entidades.ResultadoTransaccion();

            // Codigo de barras vacío en la carga de inventario
            if (codigoBarras == string.Empty)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0064");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // -- Cantidad, Cero en input carga inventario
            if (cantidad == 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0066");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // -- Cantidad negativa
            if (cantidad < 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0071");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            return CargaDescargaInventario.Cargar(codigoBarras, cantidad, kardex, ActivarPresentacionArticulo);
        }

        public ResultadoTransaccion Descargar(string codigoBarras, int cantidad, Entidades.Kardex kardex)
        {
            ReglasDENegocio.Inventario.CargaDescargaInventario CargaDescargaInventario = null;
            CargaDescargaInventario = new ReglasDENegocio.Inventario.CargaDescargaInventario();

            Entidades.ResultadoTransaccion ResultadoTransacción = new Entidades.ResultadoTransaccion();

            // Codigo de barras vacío en la descarga de inventario
            if (codigoBarras == string.Empty)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0063");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // -- Cantidad, Cero en input descarga inventario
            if (cantidad == 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0065");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            // -- Cantidad negativa
            if (cantidad < 0)
            {
                ResultadoTransacción.Mensaje = Mensajes.LinqToXml.LeerMensaje("0072");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(ResultadoTransacción.Mensaje.Texto));
                return ResultadoTransacción;
            }

            return CargaDescargaInventario.Descargar(codigoBarras, cantidad, kardex);
        }
    }
}
