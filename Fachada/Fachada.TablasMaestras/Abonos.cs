

namespace Fachada.TablasMaestras
{
    using System.Collections.ObjectModel;

    public class Abonos : Contratos.IAbonos
    {
        public ReadOnlyCollection<Entidades.Abonos> Listar(string criterioBusqueda)
        {
            // ServicioAbonos.AbonosClient objAbonos = new ServicioAbonos.AbonosClient();
            // return objAbonos.Listar(criterioBusqueda);
            return null;
        }
    }
}
