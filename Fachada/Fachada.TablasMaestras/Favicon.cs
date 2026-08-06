namespace Fachada.TablasMaestras
{
    public class Favicon : Contratos.IFavicon
    {
        public bool CargarIcono(byte[] icono)
        {
            ServicioFavicon.FaviconClient Favicon = new ServicioFavicon.FaviconClient();
            return Favicon.CargarIcono(icono);
        }

        public byte[] DescargarIcono()
        {
            ServicioFavicon.FaviconClient Favicon = new ServicioFavicon.FaviconClient();
            return Favicon.DescargarIcono();
        }

        public bool EliminarIcono()
        {
            ServicioFavicon.FaviconClient Favicon = new ServicioFavicon.FaviconClient();
            return Favicon.EliminarIcono();
        }
    }
}
