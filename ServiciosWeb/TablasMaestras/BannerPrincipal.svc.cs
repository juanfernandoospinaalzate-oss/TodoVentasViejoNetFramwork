

namespace ServiciosWeb.TablasMaestras
{
    using System;

    public class BannerPrincipal : Contratos.IBannerPrincipal
    {

        public Entidades.ResultadoTransaccion Actualizar(Entidades.BannerPrincipal banner)
        {
            Validacion.TablasMaestras.BannerPrincipal ValidacionBanner = new Validacion.TablasMaestras.BannerPrincipal();
            return ValidacionBanner.Actualizar(banner);
        }

        public Entidades.BannerPrincipal Consultar()
        {
            Validacion.TablasMaestras.BannerPrincipal ValidacionBanner = new Validacion.TablasMaestras.BannerPrincipal();
            return ValidacionBanner.Consultar();
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.BannerPrincipal banner)
        {
            Validacion.TablasMaestras.BannerPrincipal ValidacionBanner = new Validacion.TablasMaestras.BannerPrincipal();
            return ValidacionBanner.Insertar(banner);
        }
    }
}
