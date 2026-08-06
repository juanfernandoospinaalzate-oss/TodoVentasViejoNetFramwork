//-----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    using System.Collections.ObjectModel;

    public class Categoria : ContratosWeb.ICategoria
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> Listar()
        {
            AccesoDatos.WebPublica.Categoria Categoria = new AccesoDatos.WebPublica.Categoria();
            return Categoria.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.Categoria> ListarCategoriasUsadas()
        {
            AccesoDatos.WebPublica.Categoria Categoria = new AccesoDatos.WebPublica.Categoria();
            return Categoria.ListarCategoriasUsadas();
        }
    }
}
