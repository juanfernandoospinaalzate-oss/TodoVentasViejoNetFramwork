using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Validacion.TablasMaestras
{
    public class BannerPrincipal : Contratos.IBannerPrincipal
    {
        public ResultadoTransaccion Actualizar(Entidades.BannerPrincipal banner)
        {
            ReglasDENegocio.TablasMaestras.BannerPrincipal Banner = new ReglasDENegocio.TablasMaestras.BannerPrincipal();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            // Se debe gestionar cómo mínimo la pimera imágen de big banner
            if (banner.BigBanner1 == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0101");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // Se debe gestionar como mínimo la primera imágen de small banner
            if (banner.SmallBanner1 == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0102");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return Banner.Actualizar(banner);
        }

        public Entidades.BannerPrincipal Consultar()
        {
            ReglasDENegocio.TablasMaestras.BannerPrincipal Banner = new ReglasDENegocio.TablasMaestras.BannerPrincipal();
            return Banner.Consultar();
        }

        public ResultadoTransaccion Insertar(Entidades.BannerPrincipal banner)
        {
            ReglasDENegocio.TablasMaestras.BannerPrincipal Banner = new ReglasDENegocio.TablasMaestras.BannerPrincipal();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            // Se debe gestionar cómo mínimo la pimera imágen de big banner
            if (banner.BigBanner1 == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0101");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // Se debe gestionar como mínimo la primera imágen de small banner
            if (banner.SmallBanner1 == string.Empty)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0102");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return Banner.Insertar(banner);
        }
    }
}
