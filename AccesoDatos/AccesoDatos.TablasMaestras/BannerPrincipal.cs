//-----------------------------------------------------------------------
// <copyright file="BannerPrincipal.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    public class BannerPrincipal : Contratos.IBannerPrincipal
    {
        public Entidades.ResultadoTransaccion Actualizar(Entidades.BannerPrincipal banner)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramBigBanner1 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner2 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner3 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner4 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner5 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner1 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner2 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner3 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner4 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner5 = null;
            System.Data.SqlClient.SqlParameter paramVideoDataSource = null;
            System.Data.SqlClient.SqlParameter paramVideoDataId = null;
            System.Data.SqlClient.SqlParameter paramVideoImagenMiniatura = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo1 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo2 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo3 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo4 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo5 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo6 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo7 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo8 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo9 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo10 = null;
            System.Data.SqlClient.SqlParameter paramSegundoAutoplayFotorama = null;

            //// variable utilizada para manejo de la transacción y manejo de excepciones
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "BannerPrincipalUpdate";

                paramBigBanner1 = new System.Data.SqlClient.SqlParameter("@BigBanner1", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner1.Value = banner.BigBanner1;
                cmd.Parameters.Add(paramBigBanner1);

                paramBigBanner2 = new System.Data.SqlClient.SqlParameter("@BigBanner2", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner2.Value = banner.BigBanner2;
                cmd.Parameters.Add(paramBigBanner2);

                paramBigBanner3 = new System.Data.SqlClient.SqlParameter("@BigBanner3", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner3.Value = banner.BigBanner3;
                cmd.Parameters.Add(paramBigBanner3);

                paramBigBanner4 = new System.Data.SqlClient.SqlParameter("@BigBanner4", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner4.Value = banner.BigBanner4;
                cmd.Parameters.Add(paramBigBanner4);

                paramBigBanner5 = new System.Data.SqlClient.SqlParameter("@BigBanner5", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner5.Value = banner.BigBanner5;
                cmd.Parameters.Add(paramBigBanner5);

                paramSmallBanner1 = new System.Data.SqlClient.SqlParameter("@SmallBanner1", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner1.Value = banner.SmallBanner1;
                cmd.Parameters.Add(paramSmallBanner1);

                paramSmallBanner2 = new System.Data.SqlClient.SqlParameter("@SmallBanner2", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner2.Value = banner.SmallBanner2;
                cmd.Parameters.Add(paramSmallBanner2);

                paramSmallBanner3 = new System.Data.SqlClient.SqlParameter("@SmallBanner3", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner3.Value = banner.SmallBanner3;
                cmd.Parameters.Add(paramSmallBanner3);

                paramSmallBanner4 = new System.Data.SqlClient.SqlParameter("@SmallBanner4", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner4.Value = banner.SmallBanner4;
                cmd.Parameters.Add(paramSmallBanner4);

                paramSmallBanner5 = new System.Data.SqlClient.SqlParameter("@SmallBanner5", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner5.Value = banner.SmallBanner5;
                cmd.Parameters.Add(paramSmallBanner5);

                paramVideoDataSource = new System.Data.SqlClient.SqlParameter("@VideoDataSource", System.Data.SqlDbType.NVarChar, 30);
                paramVideoDataSource.Value = banner.VideoDataSource;
                cmd.Parameters.Add(paramVideoDataSource);

                paramVideoDataId = new System.Data.SqlClient.SqlParameter("@VideoDataId", System.Data.SqlDbType.NVarChar, 50);
                paramVideoDataId.Value = banner.VideoDataId;
                cmd.Parameters.Add(paramVideoDataId);

                paramVideoImagenMiniatura = new System.Data.SqlClient.SqlParameter("@VideoImagenMiniatura", System.Data.SqlDbType.NVarChar, 50);
                paramVideoImagenMiniatura.Value = banner.VideoImagenMiniatura;
                cmd.Parameters.Add(paramVideoImagenMiniatura);

                paramUrlPresentacionArticulo1 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo1", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo1.Value = banner.UrlPresentacionArticulo1;
                cmd.Parameters.Add(paramUrlPresentacionArticulo1);

                paramUrlPresentacionArticulo2 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo2", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo2.Value = banner.UrlPresentacionArticulo2;
                cmd.Parameters.Add(paramUrlPresentacionArticulo2);

                paramUrlPresentacionArticulo3 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo3", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo3.Value = banner.UrlPresentacionArticulo3;
                cmd.Parameters.Add(paramUrlPresentacionArticulo3);

                paramUrlPresentacionArticulo4 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo4", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo4.Value = banner.UrlPresentacionArticulo4;
                cmd.Parameters.Add(paramUrlPresentacionArticulo4);

                paramUrlPresentacionArticulo5 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo5", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo5.Value = banner.UrlPresentacionArticulo5;
                cmd.Parameters.Add(paramUrlPresentacionArticulo5);

                paramUrlPresentacionArticulo6 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo6", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo6.Value = banner.UrlPresentacionArticulo6;
                cmd.Parameters.Add(paramUrlPresentacionArticulo6);

                paramUrlPresentacionArticulo7 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo7", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo7.Value = banner.UrlPresentacionArticulo7;
                cmd.Parameters.Add(paramUrlPresentacionArticulo7);

                paramUrlPresentacionArticulo8 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo8", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo8.Value = banner.UrlPresentacionArticulo8;
                cmd.Parameters.Add(paramUrlPresentacionArticulo8);

                paramUrlPresentacionArticulo9 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo9", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo9.Value = banner.UrlPresentacionArticulo9;
                cmd.Parameters.Add(paramUrlPresentacionArticulo9);

                paramUrlPresentacionArticulo10 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo10", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo10.Value = banner.UrlPresentacionArticulo10;
                cmd.Parameters.Add(paramUrlPresentacionArticulo10);

                paramSegundoAutoplayFotorama = new System.Data.SqlClient.SqlParameter("@SegundoAutoplayFotorama", System.Data.SqlDbType.Int);
                paramSegundoAutoplayFotorama.Value = banner.SegundoAutoplayFotorama;
                cmd.Parameters.Add(paramSegundoAutoplayFotorama);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");

                #if Pruebas
                    cmd.Transaction.Rollback();
                    return resultadoTransaccion;
                #else
                    cmd.Transaction.Commit();
                #endif

                if (resultadoTransaccion.RegistrosAfectados == 1)
                {
                    string CarpetaImagenes = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesBanner"];

                    foreach (string ArchivoaBorrar in System.IO.Directory.GetFiles(CarpetaImagenes))
                    {
                        System.IO.File.Delete(ArchivoaBorrar);
                    }

                    this.GuardarImagenes(banner);
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0058");
                }
                else
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0057");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                resultadoTransaccion.Mensaje.Texto = "Servidor: " + ex.Server + "\n";
                resultadoTransaccion.Mensaje.Texto += "Número Error: " + ex.Number + "\n";
                resultadoTransaccion.Mensaje.Texto += "Procedimiento: " + ex.Procedure + "\n";
                resultadoTransaccion.Mensaje.Texto += "Fuente: " + ex.Source + "\n";
                resultadoTransaccion.Mensaje.Texto += "Número de Línea" + ex.LineNumber + "\n";
                resultadoTransaccion.Mensaje.Texto += "Fuente: " + ex.Source + "\n";
                resultadoTransaccion.Mensaje.Texto += "Pila de Seguimiento: " + ex.StackTrace + "\n";
                resultadoTransaccion.Mensaje.Texto += ex.Message + "\n";

                resultadoTransaccion.RegistrosAfectados = 0;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje.TipoMensaje =
                resultadoTransaccion.Mensaje.Texto = ex.Message + "\n";
                resultadoTransaccion.Mensaje.Texto += ex.StackTrace + "\n";
                resultadoTransaccion.Mensaje.Texto = "MODULO: AccesoDatos.TablasMaestras.Artículo";
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultadoTransaccion;
        }

        public Entidades.BannerPrincipal  Consultar()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            Entidades.BannerPrincipal bannerPrincipal = null;
            Entidades.Mensaje mensaje = null;
            System.Data.SqlClient.SqlDataReader reader = null;
            string NombreFuenteVideoVimeo = string.Empty;
            string NombreFuenteYoutube = string.Empty;
            string RutaImagenesBanner = string.Empty;

            try
            {
                RutaImagenesBanner = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesBanner"] + "\\";
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "BannerPrincipalSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    bannerPrincipal = new Entidades.BannerPrincipal();

                    if (reader.GetString(0) != string.Empty)
                    {
                        bannerPrincipal.BigBanner1 = reader.GetString(0);
                        bannerPrincipal.BigBanner1Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.BigBanner1);
                    }

                    if (reader.GetString(1) != string.Empty)
                    {
                        bannerPrincipal.BigBanner2 = reader.GetString(1);
                        bannerPrincipal.BigBanner2Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.BigBanner2);
                    }

                    if (reader.GetString(2) != string.Empty)
                    {
                        bannerPrincipal.BigBanner3 = reader.GetString(2);
                        bannerPrincipal.BigBanner3Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.BigBanner3);
                    }

                    if (reader.GetString(3) != string.Empty)
                    {
                        bannerPrincipal.BigBanner4 = reader.GetString(3);
                        bannerPrincipal.BigBanner4Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.BigBanner4);
                    }

                    if (reader.GetString(4) != string.Empty)
                    {
                        bannerPrincipal.BigBanner5 = reader.GetString(4);
                        bannerPrincipal.BigBanner5Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.BigBanner5);
                    }

                    if (reader.GetString(5) != string.Empty)
                    {
                        bannerPrincipal.SmallBanner1 = reader.GetString(5);
                        bannerPrincipal.SmallBanner1Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.SmallBanner1);
                    }

                    if (reader.GetString(6) != string.Empty)
                    {
                        bannerPrincipal.SmallBanner2 = reader.GetString(6);
                        bannerPrincipal.SmallBanner2Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.SmallBanner2);
                    }

                    if (reader.GetString(7) != string.Empty)
                    {
                        bannerPrincipal.SmallBanner3 = reader.GetString(7);
                        bannerPrincipal.SmallBanner3Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.SmallBanner3);
                    }

                    if (reader.GetString(8) != string.Empty)
                    {
                        bannerPrincipal.SmallBanner4 = reader.GetString(8);
                        bannerPrincipal.SmallBanner4Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.SmallBanner4);
                    }

                    if (reader.GetString(9) != string.Empty)
                    {
                        bannerPrincipal.SmallBanner5 = reader.GetString(9);
                        bannerPrincipal.SmallBanner5Binario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.SmallBanner5);
                    }

                    NombreFuenteVideoVimeo = System.Enum.GetName(typeof(Entidades.Enumeraciones.BannerPrincipalVideoDataSource), Entidades.Enumeraciones.BannerPrincipalVideoDataSource.vimeo);
                    NombreFuenteYoutube = System.Enum.GetName(typeof(Entidades.Enumeraciones.BannerPrincipalVideoDataSource), Entidades.Enumeraciones.BannerPrincipalVideoDataSource.youtube);

                    if (reader.GetString(10) == NombreFuenteVideoVimeo)
                    {
                        bannerPrincipal.VideoDataSource = Entidades.Enumeraciones.BannerPrincipalVideoDataSource.vimeo;
                    }

                    if (reader.GetString(10) == NombreFuenteYoutube)
                    {
                        bannerPrincipal.VideoDataSource = Entidades.Enumeraciones.BannerPrincipalVideoDataSource.youtube;
                    }

                    bannerPrincipal.VideoDataId = reader.GetString(11);

                    if (reader.GetString(12) != string.Empty)
                    {
                        bannerPrincipal.VideoImagenMiniatura = reader.GetString(12);
                        bannerPrincipal.VideoImagenMiniaturaBinario = System.IO.File.ReadAllBytes(RutaImagenesBanner + bannerPrincipal.VideoImagenMiniatura);
                    }

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
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                mensaje.TipoMensaje =
                mensaje.Texto = ex.Message + "\n";
                mensaje.Texto += ex.StackTrace + "\n";
                mensaje.Texto = "MODULO: AccesoDatos.TablasMaestras.Artículo";
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();

                if (reader != null)
                {
                    reader.Dispose();
                }
            }

            return bannerPrincipal;
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.BannerPrincipal banner)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramBigBanner1 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner2 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner3 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner4 = null;
            System.Data.SqlClient.SqlParameter paramBigBanner5 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner1 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner2 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner3 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner4 = null;
            System.Data.SqlClient.SqlParameter paramSmallBanner5 = null;
            System.Data.SqlClient.SqlParameter paramVideoDataSource = null;
            System.Data.SqlClient.SqlParameter paramVideoDataId = null;
            System.Data.SqlClient.SqlParameter paramVideoImagenMiniatura = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo1 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo2 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo3 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo4 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo5 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo6 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo7 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo8 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo9 = null;
            System.Data.SqlClient.SqlParameter paramUrlPresentacionArticulo10 = null;
            System.Data.SqlClient.SqlParameter paramSegundoAutoplayFotorama = null;

            //// variable utilizada para manejo de la transacción y manejo de excepciones
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "BannerPrincipalInsert";

                paramBigBanner1 = new System.Data.SqlClient.SqlParameter("@BigBanner1", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner1.Value = banner.BigBanner1;
                cmd.Parameters.Add(paramBigBanner1);

                paramBigBanner2 = new System.Data.SqlClient.SqlParameter("@BigBanner2", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner2.Value = banner.BigBanner2;
                cmd.Parameters.Add(paramBigBanner2);

                paramBigBanner3 = new System.Data.SqlClient.SqlParameter("@BigBanner3", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner3.Value = banner.BigBanner3;
                cmd.Parameters.Add(paramBigBanner3);

                paramBigBanner4 = new System.Data.SqlClient.SqlParameter("@BigBanner4", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner4.Value = banner.BigBanner4;
                cmd.Parameters.Add(paramBigBanner4);

                paramBigBanner5 = new System.Data.SqlClient.SqlParameter("@BigBanner5", System.Data.SqlDbType.NVarChar, 50);
                paramBigBanner5.Value = banner.BigBanner5;
                cmd.Parameters.Add(paramBigBanner5);

                paramSmallBanner1 = new System.Data.SqlClient.SqlParameter("@SmallBanner1", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner1.Value = banner.SmallBanner1;
                cmd.Parameters.Add(paramSmallBanner1);

                paramSmallBanner2 = new System.Data.SqlClient.SqlParameter("@SmallBanner2", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner2.Value = banner.SmallBanner2;
                cmd.Parameters.Add(paramSmallBanner2);

                paramSmallBanner3 = new System.Data.SqlClient.SqlParameter("@SmallBanner3", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner3.Value = banner.SmallBanner3;
                cmd.Parameters.Add(paramSmallBanner3);

                paramSmallBanner4 = new System.Data.SqlClient.SqlParameter("@SmallBanner4", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner4.Value = banner.SmallBanner4;
                cmd.Parameters.Add(paramSmallBanner4);

                paramSmallBanner5 = new System.Data.SqlClient.SqlParameter("@SmallBanner5", System.Data.SqlDbType.NVarChar, 50);
                paramSmallBanner5.Value = banner.SmallBanner5;
                cmd.Parameters.Add(paramSmallBanner5);

                paramVideoDataSource = new System.Data.SqlClient.SqlParameter("@VideoDataSource", System.Data.SqlDbType.NVarChar, 30);
                paramVideoDataSource.Value = banner.VideoDataSource;
                cmd.Parameters.Add(paramVideoDataSource);

                paramVideoDataId = new System.Data.SqlClient.SqlParameter("@VideoDataId", System.Data.SqlDbType.NVarChar, 50);
                paramVideoDataId.Value = banner.VideoDataId;
                cmd.Parameters.Add(paramVideoDataId);

                paramVideoImagenMiniatura = new System.Data.SqlClient.SqlParameter("@VideoImagenMiniatura", System.Data.SqlDbType.NVarChar, 50);
                paramVideoImagenMiniatura.Value = banner.VideoImagenMiniatura;
                cmd.Parameters.Add(paramVideoImagenMiniatura);

                paramUrlPresentacionArticulo1 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo1", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo1.Value = banner.UrlPresentacionArticulo1;
                cmd.Parameters.Add(paramUrlPresentacionArticulo1);

                paramUrlPresentacionArticulo2 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo2", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo2.Value = banner.UrlPresentacionArticulo2;
                cmd.Parameters.Add(paramUrlPresentacionArticulo2);

                paramUrlPresentacionArticulo3 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo3", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo3.Value = banner.UrlPresentacionArticulo3;
                cmd.Parameters.Add(paramUrlPresentacionArticulo3);

                paramUrlPresentacionArticulo4 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo4", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo4.Value = banner.UrlPresentacionArticulo4;
                cmd.Parameters.Add(paramUrlPresentacionArticulo4);

                paramUrlPresentacionArticulo5 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo5", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo5.Value = banner.UrlPresentacionArticulo5;
                cmd.Parameters.Add(paramUrlPresentacionArticulo5);

                paramUrlPresentacionArticulo6 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo6", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo6.Value = banner.UrlPresentacionArticulo6;
                cmd.Parameters.Add(paramUrlPresentacionArticulo6);

                paramUrlPresentacionArticulo7 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo7", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo7.Value = banner.UrlPresentacionArticulo7;
                cmd.Parameters.Add(paramUrlPresentacionArticulo7);

                paramUrlPresentacionArticulo8 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo8", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo8.Value = banner.UrlPresentacionArticulo8;
                cmd.Parameters.Add(paramUrlPresentacionArticulo8);

                paramUrlPresentacionArticulo9 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo9", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo9.Value = banner.UrlPresentacionArticulo9;
                cmd.Parameters.Add(paramUrlPresentacionArticulo9);

                paramUrlPresentacionArticulo10 = new System.Data.SqlClient.SqlParameter("@UrlPresentacionArticulo10", System.Data.SqlDbType.NVarChar, 500);
                paramUrlPresentacionArticulo10.Value = banner.UrlPresentacionArticulo10;
                cmd.Parameters.Add(paramUrlPresentacionArticulo10);

                paramSegundoAutoplayFotorama = new System.Data.SqlClient.SqlParameter("@SegundoAutoplayFotorama", System.Data.SqlDbType.Int);
                paramSegundoAutoplayFotorama.Value = banner.SegundoAutoplayFotorama;
                cmd.Parameters.Add(paramSegundoAutoplayFotorama);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");

                #if Pruebas
                    cmd.Transaction.Rollback();
                    return resultadoTransaccion;
#else
                cmd.Transaction.Commit();
                #endif

                if (resultadoTransaccion.RegistrosAfectados == 1)
                {
                    this.GuardarImagenes(banner);
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0058");
                }
                else
                {
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0057");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                resultadoTransaccion.Mensaje.Texto = "Servidor: " + ex.Server + "\n";
                resultadoTransaccion.Mensaje.Texto += "Número Error: " + ex.Number + "\n";
                resultadoTransaccion.Mensaje.Texto += "Procedimiento: " + ex.Procedure + "\n";
                resultadoTransaccion.Mensaje.Texto += "Fuente: " + ex.Source + "\n";
                resultadoTransaccion.Mensaje.Texto += "Número de Línea" + ex.LineNumber + "\n";
                resultadoTransaccion.Mensaje.Texto += "Fuente: " + ex.Source + "\n";
                resultadoTransaccion.Mensaje.Texto += "Pila de Seguimiento: " + ex.StackTrace + "\n";
                resultadoTransaccion.Mensaje.Texto += ex.Message + "\n";

                resultadoTransaccion.RegistrosAfectados = 0;
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje.TipoMensaje =
                resultadoTransaccion.Mensaje.Texto = ex.Message + "\n";
                resultadoTransaccion.Mensaje.Texto += ex.StackTrace + "\n";
                resultadoTransaccion.Mensaje.Texto = "MODULO: AccesoDatos.TablasMaestras.Artículo";
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultadoTransaccion;
        }

        private void GuardarImagenes(Entidades.BannerPrincipal banner)
        {
            this.GuardarImagen(banner.BigBanner1, banner.BigBanner1Binario);
            this.GuardarImagen(banner.BigBanner2, banner.BigBanner2Binario);
            this.GuardarImagen(banner.BigBanner3, banner.BigBanner3Binario);
            this.GuardarImagen(banner.BigBanner4, banner.BigBanner4Binario);
            this.GuardarImagen(banner.BigBanner5, banner.BigBanner5Binario);
            this.GuardarImagen(banner.SmallBanner1, banner.SmallBanner1Binario);
            this.GuardarImagen(banner.SmallBanner2, banner.SmallBanner2Binario);
            this.GuardarImagen(banner.SmallBanner3, banner.SmallBanner3Binario);
            this.GuardarImagen(banner.SmallBanner4, banner.SmallBanner4Binario);
            this.GuardarImagen(banner.SmallBanner5, banner.SmallBanner5Binario);
            this.GuardarImagen(banner.VideoImagenMiniatura, banner.VideoImagenMiniaturaBinario);
        }

        private void GuardarImagen(string nombreImagen, byte[] binarioImagen)
        {
            string RutaImagenesBanner = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesBanner"] + "\\";
            string RutaCompletaImagen = string.Empty;
            System.IO.MemoryStream memoryStream = null;
            System.IO.FileStream fileStream = null;

            if (nombreImagen == string.Empty || binarioImagen.Length == 0)
            {
                return;
            }
            
            RutaCompletaImagen = RutaImagenesBanner + nombreImagen;

            if (System.IO.File.Exists(RutaCompletaImagen))
            {
                System.IO.File.Delete(RutaCompletaImagen);
            }

            memoryStream = new System.IO.MemoryStream(binarioImagen);
            fileStream = new System.IO.FileStream(RutaCompletaImagen, System.IO.FileMode.Create);
            memoryStream.WriteTo(fileStream);
            fileStream.Close();
            memoryStream.Close();
        }
    }
}
