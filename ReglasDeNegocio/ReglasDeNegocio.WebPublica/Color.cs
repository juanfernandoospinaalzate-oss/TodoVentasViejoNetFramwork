//-----------------------------------------------------------------------
// <copyright file="Color.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class Color : ContratosWeb.IColor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color> ListaColores()
        {
            AccesoDatos.WebPublica.Color Color = new AccesoDatos.WebPublica.Color();
            return Color.ListaColores();
        }
    }
}
