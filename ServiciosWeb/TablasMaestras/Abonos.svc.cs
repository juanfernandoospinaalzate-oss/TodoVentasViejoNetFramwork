

namespace ServiciosWeb.TablasMaestras
{
    using System.Collections.ObjectModel;

    public class Abonos : Contratos.IAbonos
    {
        public ReadOnlyCollection<Entidades.Abonos> Listar(string criterioBusqueda)
        {
            Validacion.TablasMaestras.Abonos objAbonos = new Validacion.TablasMaestras.Abonos();
            return objAbonos.Listar(criterioBusqueda);
        }
    }
}
