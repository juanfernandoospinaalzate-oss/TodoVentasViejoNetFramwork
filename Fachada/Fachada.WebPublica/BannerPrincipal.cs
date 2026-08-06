

namespace Fachada.WebPublica
{
    public class BannerPrincipal : ContratosWeb.IBannerPrincipal
    {
        public EntidadesWeb.BannerPrincipal Consultar()
        {
            EntidadesWeb.BannerPrincipal banner = null;

            try
            {
                ServicioBannerPrincipal.BannerPrincipalClient bannerPrincipal = new ServicioBannerPrincipal.BannerPrincipalClient();
                banner = bannerPrincipal.Consultar();
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return banner;
        }
    }
}
