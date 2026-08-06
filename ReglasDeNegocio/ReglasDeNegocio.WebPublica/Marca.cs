//-----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    using System.Collections.ObjectModel;

    public class Marca : ContratosWeb.IMarca
    {
        public ReadOnlyCollection<EntidadesWeb.Marca> Listar()
        {
            AccesoDatos.WebPublica.Marca marca = new AccesoDatos.WebPublica.Marca();
            return marca.Listar();
        }
    }
}
