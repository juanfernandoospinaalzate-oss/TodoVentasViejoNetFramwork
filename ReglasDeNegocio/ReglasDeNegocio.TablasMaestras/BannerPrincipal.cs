using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ReglasDENegocio.TablasMaestras
{
    public class BannerPrincipal : Contratos.IBannerPrincipal
    {
        public ResultadoTransaccion Actualizar(Entidades.BannerPrincipal banner)
        {
            AccesoDatos.TablasMaestras.BannerPrincipal Banner = new AccesoDatos.TablasMaestras.BannerPrincipal();
            return Banner.Actualizar(banner);
        }

        public Entidades.BannerPrincipal Consultar()
        {
            AccesoDatos.TablasMaestras.BannerPrincipal Banner = new AccesoDatos.TablasMaestras.BannerPrincipal();
            return Banner.Consultar();
        }

        public ResultadoTransaccion Insertar(Entidades.BannerPrincipal banner)
        {
            AccesoDatos.TablasMaestras.BannerPrincipal Banner = new AccesoDatos.TablasMaestras.BannerPrincipal();
            return Banner.Insertar(banner);
        }
    }
}
