

namespace Validacion.TablasMaestras
{
    public class Favicon : Contratos.IFavicon
    {
        public bool CargarIcono(byte[] icono)
        {
            ReglasDENegocio.TablasMaestras.Favicon Favicon = new ReglasDENegocio.TablasMaestras.Favicon();
            return Favicon.CargarIcono(icono);
        }

        public byte[] DescargarIcono()
        {
            ReglasDENegocio.TablasMaestras.Favicon Favicon = new ReglasDENegocio.TablasMaestras.Favicon();
            return Favicon.DescargarIcono();
        }

        public bool EliminarIcono()
        {
            ReglasDENegocio.TablasMaestras.Favicon Favicon = new ReglasDENegocio.TablasMaestras.Favicon();
            return Favicon.EliminarIcono();
        }
    }
}
