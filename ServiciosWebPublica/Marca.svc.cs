

namespace ServiciosWebPublica
{
    using System.Collections.ObjectModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Marca" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Marca.svc or Marca.svc.cs at the Solution Explorer and start debugging.
    public class Marca : ContratosWeb.IMarca
    {
        public ReadOnlyCollection<EntidadesWeb.Marca> Listar()
        {
            Validacion.WebPublica.Marca Marca = new Validacion.WebPublica.Marca();
            return Marca.Listar();
        }
    }
}
