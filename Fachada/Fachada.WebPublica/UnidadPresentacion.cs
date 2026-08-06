namespace Fachada.WebPublica
{
    public class UnidadPresentacion : ContratosWeb.IUnidadPresentacion
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> Listar()
        {
            ServicioUnidadPresentacion.UnidadPresentacionClient unidadPresentacion = new ServicioUnidadPresentacion.UnidadPresentacionClient();
            return unidadPresentacion.Listar();
        }
    }
}
