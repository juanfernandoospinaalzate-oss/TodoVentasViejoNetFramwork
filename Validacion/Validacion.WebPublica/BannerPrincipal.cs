namespace Validacion.WebPublica
{
    public class BannerPrincipal : ContratosWeb.IBannerPrincipal
    {
        public EntidadesWeb.BannerPrincipal Consultar()
        {
            EntidadesWeb.BannerPrincipal banner = null;

            try
            {
                ReglasDENegocio.WebPublica.BannerPrincipal bannerPrincipal = new ReglasDENegocio.WebPublica.BannerPrincipal();
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
