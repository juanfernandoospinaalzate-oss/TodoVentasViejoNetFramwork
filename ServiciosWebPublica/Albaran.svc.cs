

namespace ServiciosWebPublica
{
    using EntidadesWeb;

    public class Albaran : ContratosWeb.IAlbaran
    {
        public ResultadoTransaccion Actualizar(EntidadesWeb.Albaran albaran)
        {
            Validacion.WebPublica.Albaran Albaran = new Validacion.WebPublica.Albaran();
            return Albaran.Actualizar(albaran);
        }
    }
}
