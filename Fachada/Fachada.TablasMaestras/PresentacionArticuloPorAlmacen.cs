namespace Fachada.TablasMaestras
{
    public class PresentacionArticuloPorAlmacen : Contratos.IPresentacionArticuloPorAlmacen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> Listar()
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.Listar();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticulo()
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticulo();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticuloPorAlmacen(int idAlmacen)
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(idAlmacen);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.Actualizar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticuloPorAlmacen)
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.Eliminar(idPresentacionArticuloPorAlmacen);
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.Insertar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
        
        public Entidades.ResultadoTransaccion ActualizarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.ActualizarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion InsertarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient PresentacionArticuloPorAlmacen = new ServicioPresentacionArticuloPorAlmacen.PresentacionArticuloPorAlmacenClient();
            return PresentacionArticuloPorAlmacen.InsertarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
    }
}
