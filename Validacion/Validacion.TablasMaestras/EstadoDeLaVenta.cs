namespace Validacion.TablasMaestras
{
    public class EstadoDeLaVenta : Contratos.IEstadoVenta
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            ReglasDENegocio.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new ReglasDENegocio.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Insertar(estadoDeLaVenta);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            ReglasDENegocio.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new ReglasDENegocio.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Actualizar(estadoDeLaVenta);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.EstadoVenta> Listar()
        {
            ReglasDENegocio.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new ReglasDENegocio.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Listar();
        }


        public Entidades.ResultadoTransaccion Eliminar(int idEstadoVenta)
        {
            ReglasDENegocio.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new ReglasDENegocio.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Eliminar(idEstadoVenta);
        }
    }
}
