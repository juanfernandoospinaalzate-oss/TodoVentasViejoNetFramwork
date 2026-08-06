

namespace Fachada.WebPublica
{
    using EntidadesWeb;

    public class Albaran : ContratosWeb.IAlbaran
    {
        public ResultadoTransaccion Actualizar(EntidadesWeb.Albaran albaran)
        {
            ServicioAlbaran.AlbaranClient Albaran = new ServicioAlbaran.AlbaranClient();
            return Albaran.Actualizar(albaran);
        }
    }
}
