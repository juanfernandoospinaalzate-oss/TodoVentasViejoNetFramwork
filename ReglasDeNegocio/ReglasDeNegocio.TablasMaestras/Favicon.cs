namespace ReglasDENegocio.TablasMaestras
{
    public class Favicon : Contratos.IFavicon
    {
        public bool CargarIcono(byte[] icono)
        {
            AccesoDatos.TablasMaestras.Favicon Favicon = new AccesoDatos.TablasMaestras.Favicon();
            return Favicon.CargarIcono(icono);
        }

        public byte[] DescargarIcono()
        {
            AccesoDatos.TablasMaestras.Favicon Favicon = new AccesoDatos.TablasMaestras.Favicon();
            return Favicon.DescargarIcono();
        }

        public bool EliminarIcono()
        {
            AccesoDatos.TablasMaestras.Favicon Favicon = new AccesoDatos.TablasMaestras.Favicon();
            return Favicon.EliminarIcono();
        }
    }
}
