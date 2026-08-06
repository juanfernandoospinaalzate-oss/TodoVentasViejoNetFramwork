

namespace Fachada.WebPublica
{
    using System.Collections.ObjectModel;

    public class Marca : ContratosWeb.IMarca
    {
        public ReadOnlyCollection<EntidadesWeb.Marca> Listar()
        {
            ServicioMarca.MarcaClient Marca = new ServicioMarca.MarcaClient();
            return Marca.Listar();
        }
    }
}
