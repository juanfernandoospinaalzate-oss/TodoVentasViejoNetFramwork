//-----------------------------------------------------------------------
// <copyright file="UnidadLongitud.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class UnidadLongitud : ContratosWeb.IUnidadLongitud
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> ListaUnidadLongitud()
        {
            AccesoDatos.WebPublica.UnidadLongitud UnidadLongitud = new AccesoDatos.WebPublica.UnidadLongitud();
            return UnidadLongitud.ListaUnidadLongitud();
        }
    }
}
