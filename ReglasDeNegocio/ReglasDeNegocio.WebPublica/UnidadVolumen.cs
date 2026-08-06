// -----------------------------------------------------------------------
// <copyright file="UnidadVolumen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class UnidadVolumen : ContratosWeb.IUnidadVolumen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> ListaUnidadVolumen()
        {
            AccesoDatos.WebPublica.UnidadVolumen UnidadVolumen = new AccesoDatos.WebPublica.UnidadVolumen();
            return UnidadVolumen.ListaUnidadVolumen();
        }
    }
}
