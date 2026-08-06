namespace ServiciosWeb.Facturacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ConfiguracionFactura" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ConfiguracionFactura.svc o ConfiguracionFactura.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ConfiguracionFactura : Contratos.IConfiguracionFactura
    {
        public Entidades.ResultadoTransaccion Guardar(Entidades.ConfiguracionFactura configuracionFactura)
        {
            Validacion.Facturacion.ConfiguracionFactura ConfiguracionFactura = new Validacion.Facturacion.ConfiguracionFactura();
            return ConfiguracionFactura.Guardar(configuracionFactura);
        }


        public Entidades.ResultadoTransaccion Actualizar(int nroFactura)
        {
            Validacion.Facturacion.ConfiguracionFactura ConfiguracionFactura = new Validacion.Facturacion.ConfiguracionFactura();
            return ConfiguracionFactura.Actualizar(nroFactura);
        }
    }
}
