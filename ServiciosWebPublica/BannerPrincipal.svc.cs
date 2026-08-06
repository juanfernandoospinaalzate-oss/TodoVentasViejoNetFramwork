

namespace ServiciosWebPublica
{
    public class BannerPrincipal : ContratosWeb.IBannerPrincipal
    {
        public EntidadesWeb.BannerPrincipal Consultar()
        {
            EntidadesWeb.BannerPrincipal banner = null;

            try
            {
                Validacion.WebPublica.BannerPrincipal bannerPrincipal = new Validacion.WebPublica.BannerPrincipal();
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
