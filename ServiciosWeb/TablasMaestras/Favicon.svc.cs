namespace ServiciosWeb.TablasMaestras
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Favicon" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Favicon.svc or Favicon.svc.cs at the Solution Explorer and start debugging.
    public class Favicon : Contratos.IFavicon
    {
        public bool CargarIcono(byte[] icono)
        {
            Validacion.TablasMaestras.Favicon Favicon = new Validacion.TablasMaestras.Favicon();
            return Favicon.CargarIcono(icono);
        }

        public byte[] DescargarIcono()
        {
            Validacion.TablasMaestras.Favicon Favicon = new Validacion.TablasMaestras.Favicon();
            return Favicon.DescargarIcono();
        }

        public bool EliminarIcono()
        {
            Validacion.TablasMaestras.Favicon Favicon = new Validacion.TablasMaestras.Favicon();
            return Favicon.EliminarIcono();
        }
    }
}
