// -----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Validacion.WebPublica
{
    using System.Collections.ObjectModel;

    public class Categoria : ContratosWeb.ICategoria
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> Listar()
        {
            ReglasDENegocio.WebPublica.Categoria Categoria = new ReglasDENegocio.WebPublica.Categoria();
            return Categoria.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.Categoria> ListarCategoriasUsadas()
        {
            ReglasDENegocio.WebPublica.Categoria Categoria = new ReglasDENegocio.WebPublica.Categoria();
            return Categoria.ListarCategoriasUsadas();
        }
    }
}
