namespace Fachada.WebPublica
{
    public class Sabor : ContratosWeb.ISabor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> ListaSabores()
        {
            ServicioSabor.SaborClient Sabor = new ServicioSabor.SaborClient();
            return Sabor.ListaSabores();
        }
    }
}
