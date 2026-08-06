//-----------------------------------------------------------------------
// <copyright file="BannerPrincipal.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class BannerPrincipal : ContratosWeb.IBannerPrincipal
    {
        public EntidadesWeb.BannerPrincipal Consultar()
        {
            EntidadesWeb.BannerPrincipal banner = null;

            try
            {
                AccesoDatos.WebPublica.BannerPrincipal bannerPrincipal = new AccesoDatos.WebPublica.BannerPrincipal();
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
