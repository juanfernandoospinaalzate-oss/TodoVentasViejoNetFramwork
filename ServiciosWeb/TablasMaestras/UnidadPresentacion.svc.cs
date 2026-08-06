namespace ServiciosWeb.TablasMaestras
{
    public class UnidadPresentacion : Contratos.IUnidadPresentacion
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            Validacion.TablasMaestras.UnidadPresentacion unidadesPresentacion = new Validacion.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Insertar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            Validacion.TablasMaestras.UnidadPresentacion unidadesPresentacion = new Validacion.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Actualizar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Eliminar(int IdUnidadPresentacion)
        {
            Validacion.TablasMaestras.UnidadPresentacion unidadesPresentacion = new Validacion.TablasMaestras.UnidadPresentacion();
            return unidadesPresentacion.Eliminar(IdUnidadPresentacion);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadPresentacion> Listar()
        {
            Validacion.TablasMaestras.UnidadPresentacion unidadPresentacion = new Validacion.TablasMaestras.UnidadPresentacion();
            return unidadPresentacion.Listar();
        }
    }
}
