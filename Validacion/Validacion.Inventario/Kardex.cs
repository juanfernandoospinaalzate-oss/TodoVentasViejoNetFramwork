

namespace Validacion.Inventario
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class Kardex : Contratos.IKardex
    {
        public bool VerificarRelacionPresentacionArticulo(int idPresentacionArticulo)
        {
            ReglasDENegocio.Inventario.Kardex Kardex = new ReglasDENegocio.Inventario.Kardex();
            return Kardex.VerificarRelacionPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion Insertar(Entidades.Kardex registro)
        {
            ReglasDENegocio.Inventario.Kardex Kardex = new ReglasDENegocio.Inventario.Kardex();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            // CantidadEntrada y CantidadSalida no pueden ser diferentes a cero simultaneamente
            if (registro.CantidadEntrada != 0 && registro.CantidadSalida != 0)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0082");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // CantidadEntrada y CantidadSalida no puede ser igual a cero simultaneamente
            if (registro.CantidadEntrada == 0 && registro.CantidadSalida == 0)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0083");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return Kardex.Insertar(registro);
        }

        public ReadOnlyCollection<Entidades.Kardex> ListarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            ReglasDENegocio.Inventario.Kardex Kardex = new ReglasDENegocio.Inventario.Kardex();
            return Kardex.ListarPorIdPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
