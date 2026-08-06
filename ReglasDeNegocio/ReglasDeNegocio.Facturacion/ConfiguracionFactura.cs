// -----------------------------------------------------------------------
// <copyright file="ConfiguracionFactura.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.Facturacion
{
    public class ConfiguracionFactura : Contratos.IConfiguracionFactura
    {
        public Entidades.ResultadoTransaccion Guardar(Entidades.ConfiguracionFactura configuracionFactura)
        {
            AccesoDatos.Facturacion.ConfiguracionFactura ConfiguracionFactura = new AccesoDatos.Facturacion.ConfiguracionFactura();
            return ConfiguracionFactura.Guardar(configuracionFactura);
        }

        public Entidades.ResultadoTransaccion Actualizar(int NroFactura)
        {
            AccesoDatos.Facturacion.ConfiguracionFactura ConfiguracionFactura = new AccesoDatos.Facturacion.ConfiguracionFactura();
            return ConfiguracionFactura.Actualizar(NroFactura);
        }
    }
}
