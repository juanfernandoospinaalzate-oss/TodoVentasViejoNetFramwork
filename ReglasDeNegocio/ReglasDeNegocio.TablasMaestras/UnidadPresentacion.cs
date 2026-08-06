namespace ReglasDENegocio.TablasMaestras
{
    public class UnidadPresentacion : Contratos.IUnidadPresentacion
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            AccesoDatos.TablasMaestras.UnidadPresentacion unidadesPresentacion = new AccesoDatos.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Insertar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            AccesoDatos.TablasMaestras.UnidadPresentacion unidadesPresentacion = new AccesoDatos.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Actualizar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Eliminar(int IdUnidadPresentacion)
        {
            AccesoDatos.TablasMaestras.UnidadPresentacion unidadesPresentacion = new AccesoDatos.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Eliminar(IdUnidadPresentacion);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadPresentacion> Listar()
        {
            AccesoDatos.TablasMaestras.UnidadPresentacion unidadPresentacion = new AccesoDatos.TablasMaestras.UnidadPresentacion();
            return unidadPresentacion.Listar();
        }
    }
}
