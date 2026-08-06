// -----------------------------------------------------------------------
// <copyright file="Abonos.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using System.Collections.ObjectModel;

    public class Abonos : Contratos.IAbonos
    {
        public ReadOnlyCollection<Entidades.Abonos> Listar(string criterioBusqueda)
        {
            AccesoDatos.TablasMaestras.Abonos objAbonos = new AccesoDatos.TablasMaestras.Abonos();
            return objAbonos.Listar(criterioBusqueda);
        }
    }
}
