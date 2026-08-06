namespace Validacion.TablasMaestras
{
    public class UnidadPresentacion : Contratos.IUnidadPresentacion
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            ReglasDENegocio.TablasMaestras.UnidadPresentacion unidadesPresentacion = new ReglasDENegocio.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Insertar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            ReglasDENegocio.TablasMaestras.UnidadPresentacion unidadesPresentacion = new ReglasDENegocio.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Actualizar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Eliminar(int IdUnidadPresentacion)
        {
            ReglasDENegocio.TablasMaestras.UnidadPresentacion unidadesPresentacion = new ReglasDENegocio.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Eliminar(IdUnidadPresentacion);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadPresentacion> Listar()
        {
            ReglasDENegocio.TablasMaestras.UnidadPresentacion unidadPresentacion = new ReglasDENegocio.TablasMaestras.UnidadPresentacion();
            return unidadPresentacion.Listar();
        }
    }
}
