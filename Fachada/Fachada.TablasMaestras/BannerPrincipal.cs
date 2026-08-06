using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Fachada.TablasMaestras
{
    public class BannerPrincipal : Contratos.IBannerPrincipal
    {
        public ResultadoTransaccion Actualizar(Entidades.BannerPrincipal banner)
        {
            ServicioBannerPrincipal.BannerPrincipalClient ClienteBanner = new ServicioBannerPrincipal.BannerPrincipalClient();
            return ClienteBanner.Actualizar(banner);
        }

        public Entidades.BannerPrincipal Consultar()
        {
            ServicioBannerPrincipal.BannerPrincipalClient ClienteBanner = new ServicioBannerPrincipal.BannerPrincipalClient();
            return ClienteBanner.Consultar();
        }

        public ResultadoTransaccion Insertar(Entidades.BannerPrincipal banner)
        {
            ServicioBannerPrincipal.BannerPrincipalClient ClienteBanner = new ServicioBannerPrincipal.BannerPrincipalClient();
            return ClienteBanner.Insertar(banner);
        }
    }
}
