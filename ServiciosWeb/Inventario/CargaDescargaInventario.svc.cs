namespace ServiciosWeb.Inventario
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CargaDescargaInventario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CargaDescargaInventario.svc or CargaDescargaInventario.svc.cs at the Solution Explorer and start debugging.
    public class CargaDescargaInventario : Contratos.ICargaDescargaInventario
    {
        public Entidades.ResultadoTransaccion Cargar(string codigoBarras, int cantidad, Entidades.Kardex kardex, bool ActivarPresentacionArticulo)
        {
            Validacion.Inventario.CargaDescartaInventario CargaDescargaInventario = null;
            CargaDescargaInventario = new Validacion.Inventario.CargaDescartaInventario();
            return CargaDescargaInventario.Cargar(codigoBarras, cantidad, kardex, ActivarPresentacionArticulo);
        }

        public Entidades.ResultadoTransaccion Descargar(string codigoBarras, int cantidad, Entidades.Kardex kardex)
        {
            Validacion.Inventario.CargaDescartaInventario CargaDescargaInventario = null;
            CargaDescargaInventario = new Validacion.Inventario.CargaDescartaInventario();
            return CargaDescargaInventario.Descargar(codigoBarras, cantidad, kardex);
        }
    }
}
