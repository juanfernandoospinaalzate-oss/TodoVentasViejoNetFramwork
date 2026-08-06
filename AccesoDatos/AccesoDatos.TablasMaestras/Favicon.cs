

namespace AccesoDatos.TablasMaestras
{
    using System;

    public class Favicon : Contratos.IFavicon
    {
        public bool CargarIcono(byte[] icono)
        {
            System.IO.MemoryStream MemoryStream = null;
            System.IO.FileStream FileStream = null;
            string RutaFavicon = string.Empty;

            try
            {
                MemoryStream = new System.IO.MemoryStream(icono);
                RutaFavicon = System.Configuration.ConfigurationManager.AppSettings["RutaSitioWeb"] + "\\Icono_Favicon.ico";

                if (System.IO.File.Exists(RutaFavicon) == true)
                {
                    System.IO.File.Delete(RutaFavicon);
                }

                FileStream = new System.IO.FileStream(RutaFavicon, System.IO.FileMode.Create);
                MemoryStream.WriteTo(FileStream);
                MemoryStream.Close();
                FileStream.Close();
                return true;
            }
            catch (System.IO.IOException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return false;
        }

        public byte[] DescargarIcono()
        {
            string RutaFavicon = string.Empty;
            byte[] IconoFavicon = null;

            try
            {
                RutaFavicon = System.Configuration.ConfigurationManager.AppSettings["RutaSitioWeb"] + "\\Icono_Favicon.ico";
                IconoFavicon = System.IO.File.ReadAllBytes(RutaFavicon);
                return IconoFavicon;
            }
            catch (System.IO.IOException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public bool EliminarIcono()
        {
            string RutaFavicon = string.Empty;
            bool ArchivoExiste = false;

            try
            {
                RutaFavicon = System.Configuration.ConfigurationManager.AppSettings["RutaSitioWeb"] + "\\Icono_Favicon.ico";
                ArchivoExiste = System.IO.File.Exists(RutaFavicon);

                if (ArchivoExiste == true)
                {
                    System.IO.File.Delete(RutaFavicon);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.IO.IOException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return false;
        }
    }
}
