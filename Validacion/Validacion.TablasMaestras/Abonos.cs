

namespace Validacion.TablasMaestras
{
    using System.Collections.ObjectModel;

    public class Abonos : Contratos.IAbonos
    {
        public ReadOnlyCollection<Entidades.Abonos> Listar(string criterioBusqueda)
        {
            ReglasDENegocio.TablasMaestras.Abonos objAbonos = new ReglasDENegocio.TablasMaestras.Abonos();
            return objAbonos.Listar(criterioBusqueda);
        }
    }
}
