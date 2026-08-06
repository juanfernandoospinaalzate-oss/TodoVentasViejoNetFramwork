namespace ServiciosWeb.TablasMaestras
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EstadoDeLaVenta" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EstadoDeLaVenta.svc o EstadoDeLaVenta.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EstadoDeLaVenta : Contratos.IEstadoVenta
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            Validacion.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new Validacion.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Insertar(estadoDeLaVenta);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            Validacion.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new Validacion.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Actualizar(estadoDeLaVenta);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.EstadoVenta> Listar()
        {
            Validacion.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new Validacion.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Listar();
        }


        public Entidades.ResultadoTransaccion Eliminar(int idEstadoVenta)
        {
            Validacion.TablasMaestras.EstadoDeLaVenta EstadoDeLaVenta = new Validacion.TablasMaestras.EstadoDeLaVenta();
            return EstadoDeLaVenta.Eliminar(idEstadoVenta);
        }
    }
}
