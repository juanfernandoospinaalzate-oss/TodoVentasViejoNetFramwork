

namespace Fachada.WebPublica
{
    using System.Collections.ObjectModel;

    public class Categoria : ContratosWeb.ICategoria
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> Listar()
        {
            ServicioCategoria.CategoriaClient Categoria = new ServicioCategoria.CategoriaClient();
            return Categoria.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.Categoria> ListarCategoriasUsadas()
        {
            ServicioCategoria.CategoriaClient Categoria = new ServicioCategoria.CategoriaClient();
            return Categoria.ListarCategoriasUsadas();
        }
    }
}
