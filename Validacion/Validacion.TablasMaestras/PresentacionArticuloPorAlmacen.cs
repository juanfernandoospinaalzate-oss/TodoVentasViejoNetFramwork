namespace Validacion.TablasMaestras
{
    public class PresentacionArticuloPorAlmacen : Contratos.IPresentacionArticuloPorAlmacen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> Listar()
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Listar();
        }
        
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticulo()
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticulo();
        }
        
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticuloPorAlmacen(int idAlmacen)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(idAlmacen);
        }
        
        public Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            if (presentacionArticuloPorAlmacen.Existencia < unidadesTransferidas)
            {
                // No se puede transferir dicha cantidad. ha sido excedida.                
            }

            return PresentacionArticuloPorAlmacen.Actualizar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
        
        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticuloPorAlmacen)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Eliminar(idPresentacionArticuloPorAlmacen);
        }
        
        public Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Insertar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
        
        public Entidades.ResultadoTransaccion ActualizarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ActualizarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion InsertarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new ReglasDENegocio.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.InsertarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
    }
}
