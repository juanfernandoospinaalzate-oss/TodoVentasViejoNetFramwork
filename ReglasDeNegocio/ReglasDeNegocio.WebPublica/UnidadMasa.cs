// -----------------------------------------------------------------------
// <copyright file="UnidadMasa.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class UnidadMasa : ContratosWeb.IUnidadMasa
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa> ListaUnidadMasa()
        {
            AccesoDatos.WebPublica.UnidadMasa UnidadMasa = new AccesoDatos.WebPublica.UnidadMasa();
            return UnidadMasa.ListaUnidadMasa();
        }
    }
}
