//-----------------------------------------------------------------------
// <copyright file="Talla.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class Talla : ContratosWeb.ITalla
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla> ListaTallas()
        {
            AccesoDatos.WebPublica.Talla Talla = new AccesoDatos.WebPublica.Talla();
            return Talla.ListaTallas();
        }
    }
}
