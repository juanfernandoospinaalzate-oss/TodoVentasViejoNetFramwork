namespace Fachada.Inventario
{
    public class CargaDescargaInventario : Contratos.ICargaDescargaInventario
    {
        public Entidades.ResultadoTransaccion Cargar(string codigoBarras, int cantidad, Entidades.Kardex kardex, bool ActivarPresentacionArticulo)
        {
            ServicioCargaDescargaInventario.CargaDescargaInventarioClient CargaDescarga = null;
            CargaDescarga = new ServicioCargaDescargaInventario.CargaDescargaInventarioClient();
            return CargaDescarga.Cargar(codigoBarras, cantidad, kardex, ActivarPresentacionArticulo);
        }

        public Entidades.ResultadoTransaccion Descargar(string codigoBarras, int cantidad, Entidades.Kardex kardex)
        {
            ServicioCargaDescargaInventario.CargaDescargaInventarioClient CargaDescarga = null;
            CargaDescarga = new ServicioCargaDescargaInventario.CargaDescargaInventarioClient();
            return CargaDescarga.Descargar(codigoBarras, cantidad, kardex);
        }
    }
}
