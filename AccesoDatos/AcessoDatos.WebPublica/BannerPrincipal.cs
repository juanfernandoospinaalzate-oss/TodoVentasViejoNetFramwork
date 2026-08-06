//-----------------------------------------------------------------------
// <copyright file="BannerPrincipal.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    public class BannerPrincipal : ContratosWeb.IBannerPrincipal
    {
        public EntidadesWeb.BannerPrincipal Consultar()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            EntidadesWeb.BannerPrincipal bannerPrincipal = null;
            EntidadesWeb.Mensaje mensaje = new EntidadesWeb.Mensaje();
            System.Data.SqlClient.SqlDataReader reader = null;
            string NombreFuenteVideoVimeo = string.Empty;
            string NombreFuenteYoutube = string.Empty;
            string UrlPresentacionArticulo = string.Empty;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "BannerPrincipalSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    bannerPrincipal = new EntidadesWeb.BannerPrincipal();
                    bannerPrincipal.BigBanner1 = reader.GetString(0);
                    bannerPrincipal.BigBanner2 = reader.GetString(1);
                    bannerPrincipal.BigBanner3 = reader.GetString(2);
                    bannerPrincipal.BigBanner4 = reader.GetString(3);
                    bannerPrincipal.BigBanner5 = reader.GetString(4);
                    bannerPrincipal.SmallBanner1 = reader.GetString(5);
                    bannerPrincipal.SmallBanner2 = reader.GetString(6);
                    bannerPrincipal.SmallBanner3 = reader.GetString(7);
                    bannerPrincipal.SmallBanner4 = reader.GetString(8);
                    bannerPrincipal.SmallBanner5 = reader.GetString(9);

                    NombreFuenteVideoVimeo = System.Enum.GetName(typeof(EntidadesWeb.Enumeraciones.BannerPrincipalVideoDataSource), EntidadesWeb.Enumeraciones.BannerPrincipalVideoDataSource.vimeo);
                    NombreFuenteYoutube = System.Enum.GetName(typeof(EntidadesWeb.Enumeraciones.BannerPrincipalVideoDataSource), EntidadesWeb.Enumeraciones.BannerPrincipalVideoDataSource.youtube);

                    if (reader.GetString(10) == NombreFuenteVideoVimeo)
                    {
                        bannerPrincipal.VideoDataSource = EntidadesWeb.Enumeraciones.BannerPrincipalVideoDataSource.vimeo;
                    }

                    if (reader.GetString(10) == NombreFuenteYoutube)
                    {
                        bannerPrincipal.VideoDataSource = EntidadesWeb.Enumeraciones.BannerPrincipalVideoDataSource.youtube;
                    }

                    bannerPrincipal.VideoDataId = reader.GetString(11);
                    bannerPrincipal.VideoImagenMiniatura = reader.GetString(12);
                    bannerPrincipal.UrlPresentacionArticulo1 = reader.GetString(13);
                    bannerPrincipal.UrlPresentacionArticulo2 = reader.GetString(14);
                    bannerPrincipal.UrlPresentacionArticulo3 = reader.GetString(15);
                    bannerPrincipal.UrlPresentacionArticulo4 = reader.GetString(16);
                    bannerPrincipal.UrlPresentacionArticulo5 = reader.GetString(17);
                    bannerPrincipal.UrlPresentacionArticulo6 = reader.GetString(18);
                    bannerPrincipal.UrlPresentacionArticulo7 = reader.GetString(19);
                    bannerPrincipal.UrlPresentacionArticulo8 = reader.GetString(20);
                    bannerPrincipal.UrlPresentacionArticulo9 = reader.GetString(21);
                    bannerPrincipal.UrlPresentacionArticulo10 = reader.GetString(22);
                    bannerPrincipal.SegundoAutoplayFotorama = reader.GetInt32(23);
                }
                else
                {
                    // la tabla está vacía
                    return null;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                mensaje.Texto = "Servidor: " + ex.Server + "\n";
                mensaje.Texto += "Número Error: " + ex.Number + "\n";
                mensaje.Texto += "Procedimiento: " + ex.Procedure + "\n";
                mensaje.Texto += "Fuente: " + ex.Source + "\n";
                mensaje.Texto += "Número de Línea" + ex.LineNumber + "\n";
                mensaje.Texto += "Fuente: " + ex.Source + "\n";
                mensaje.Texto += "Pila de Seguimiento: " + ex.StackTrace + "\n";
                mensaje.Texto += ex.Message + "\n";
                Logging.ErrorGeneral.Guardar(ex);
                return null;
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
            {
                mensaje.TipoMensaje =
                mensaje.Texto = ex.Message + "\n";
                mensaje.Texto += ex.StackTrace + "\n";
                mensaje.Texto = "MODULO: AccesoDatos.TablasMaestras.Artículo";
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                return null;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (reader != null)
                {
                    reader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return bannerPrincipal;
        }
    }
}
