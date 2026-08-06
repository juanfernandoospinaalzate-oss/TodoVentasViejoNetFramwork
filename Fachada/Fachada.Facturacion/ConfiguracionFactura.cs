namespace Fachada.Facturacion
{
    public class ConfiguracionFactura : Contratos.IConfiguracionFactura
    {
        public Entidades.ResultadoTransaccion Guardar(Entidades.ConfiguracionFactura configuracionFactura)
        {
            ServicioConfiguracionFactura.ConfiguracionFacturaClient ConfiguracionFactura = new ServicioConfiguracionFactura.ConfiguracionFacturaClient();
            return ConfiguracionFactura.Guardar(configuracionFactura);
        }


        public Entidades.ResultadoTransaccion Actualizar(int NroFactura)
        {
            ServicioConfiguracionFactura.ConfiguracionFacturaClient ConfiguracionFactura = new ServicioConfiguracionFactura.ConfiguracionFacturaClient();
            return ConfiguracionFactura.Actualizar(NroFactura);
        }
    }
}
