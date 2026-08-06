namespace Validacion.Facturacion
{
    public class ConfiguracionFactura : Contratos.IConfiguracionFactura
    {
        public Entidades.ResultadoTransaccion Guardar(Entidades.ConfiguracionFactura configuracionFactura)
        {
            ReglasDENegocio.Facturacion.ConfiguracionFactura ConfiguracionFactura = new ReglasDENegocio.Facturacion.ConfiguracionFactura();
            return ConfiguracionFactura.Guardar(configuracionFactura);
        }


        public Entidades.ResultadoTransaccion Actualizar(int NroFactura)
        {
            ReglasDENegocio.Facturacion.ConfiguracionFactura ConfiguracionFactura = new ReglasDENegocio.Facturacion.ConfiguracionFactura();
            return ConfiguracionFactura.Actualizar(NroFactura);
        }
    }
}
