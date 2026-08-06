// -----------------------------------------------------------------------
// <copyright file="UnidadPresentacion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class UnidadPresentacion : ContratosWeb.IUnidadPresentacion
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> Listar()
        {
            AccesoDatos.WebPublica.UnidadPresentacion unidadPresentacion = new AccesoDatos.WebPublica.UnidadPresentacion();
            return unidadPresentacion.Listar();
        }
    }
}
